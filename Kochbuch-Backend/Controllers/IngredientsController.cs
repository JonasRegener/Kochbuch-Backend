using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kochbuch_Backend.Data;
using Kochbuch_Backend.Contracts;
using Kochbuch_Backend.Repository;
using AutoMapper;
using Kochbuch_Backend.Models.Ingredient;

namespace Kochbuch_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsRepository _ingredientsRepository;
        private readonly IMapper _mapper;

        public IngredientsController(IIngredientsRepository ingredientsRepository, IMapper mapper)
        {
            this._ingredientsRepository = ingredientsRepository;
            this._mapper = mapper;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetIngredients()
        {
            var ingredients = await _ingredientsRepository.GetAllAsync();
            return _mapper.Map<List<IngredientDto>>(ingredients);
        }
        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetIngredientDto>> GetIngredient(int id)
        {
            var ingredient = await _ingredientsRepository.GetAsync(id); 

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Ingredient>(ingredient));
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        // need refactor put
        public async Task<IActionResult> PutIngredient(int id, UpdateIngredientDto updateIngredient)
        {
            if (id != updateIngredient.Id)
            {
                return BadRequest();
            }
            var ingredient = await _ingredientsRepository.GetAsync(id);
            /// _context.Entry(ingredient).State = EntityState.Modified;
            
            if(ingredient == null)
            {
                return NotFound();
            }

            _mapper.Map(updateIngredient, ingredient);

            try
            {
                await _ingredientsRepository.UpdateAsync(ingredient);
            }
            catch (DbUpdateConcurrencyException)
            {
                bool awaitBool = await IngredientExists(id);
                if (!awaitBool)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(IngredientDto ingredientDto)
        {
            var ingredient = _mapper.Map<Ingredient>(ingredientDto);
            await _ingredientsRepository.AddAsync(ingredient);
           
            return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _ingredientsRepository.GetAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            await _ingredientsRepository.DeleteAsync(id);
           

            return NoContent();
        }

        private async Task<bool>  IngredientExists(int id)
        {
            return await _ingredientsRepository.Exisits(id);
        }
    }
}
