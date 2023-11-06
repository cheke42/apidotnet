
using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly ILogger<VillaNumberController> _logger;
        private readonly IVillaRepository _villaRepository;
        private readonly IVillaNumberRepository _villaNumberRepository;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public VillaNumberController(ILogger<VillaNumberController> logger,IVillaRepository villaRepository, IVillaNumberRepository villaNumberRepository, IMapper mapper) { 
            _logger = logger;
            _villaRepository = villaRepository;
            _villaNumberRepository = villaNumberRepository;
            _mapper = mapper;
            _response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillasNumber()
        {
            try
            {
                _logger.LogInformation("Obtener Numeros Villas");
                IEnumerable<VillaNumber> villaNumberList = await _villaNumberRepository.GetAll();
                _response.result = _mapper.Map<IEnumerable<VillaNumberDto>>(villaNumberList);
                _response.statusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex) {
                _response.isSuccess = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
            
        }

        [HttpGet("id:int",Name = "GetNumberVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error al traer Numero Villa con ID " + id);
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var villaNumber = await _villaNumberRepository.Get(v => v.VillaNo == id);
                if (villaNumber == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.result = _mapper.Map<VillaNumberDto>(villaNumber);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.errorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> CreateVillaNumber([FromBody] VillaNumberCreateDto createNumberDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _villaNumberRepository.Get(v => v.VillaNo == createNumberDto.VillaNo) != null){
                ModelState.AddModelError("ExistentVillaNo", "The specific villa number is exist");
                return BadRequest(ModelState);
            }

            if (await _villaRepository.Get(v=> v.Id == createNumberDto.VillaId) == null)
            {
                ModelState.AddModelError("ForeignKey", "The specific villa Id isn't exist");
                return BadRequest(ModelState);
            }

            if (createNumberDto == null)
            {
                return BadRequest(createNumberDto);
            }

            VillaNumber model = _mapper.Map<VillaNumber>(createNumberDto);
            model.CreationDate = DateTime.Now;
            model.UpdateDate = DateTime.Now;
            await _villaNumberRepository.Create(model);
            return CreatedAtRoute("GetNumberVilla",new {id= model.VillaNo}, model);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteNumberVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var villaNumber = await _villaNumberRepository.Get(v => v.VillaNo == id);

            if (villaNumber == null)
            {
                return NotFound();
            }
            _villaNumberRepository.Remove(villaNumber);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDto updateNumberDto)
        {
            if(updateNumberDto == null || id!= updateNumberDto.VillaNo)
            {
                _response.isSuccess = false;
                _response.statusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            if(await _villaRepository.Get(v => v.Id == updateNumberDto.VillaId) == null)
            {
                ModelState.AddModelError("ForeignKey", "The specific villa Id isn't exist");
                return BadRequest(ModelState);
            }

            VillaNumber modelNumber = _mapper.Map<VillaNumber>(updateNumberDto);
            _villaNumberRepository.Update(modelNumber);
            return NoContent();
        }



    }
}
