﻿using BlazorBattles.Server.Data;
using BlazorBattles.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBattles.Server.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UnitController : ControllerBase
   {
      private readonly DataContext _context;

      public UnitController(DataContext context)
      {
         _context = context;
      }

      [HttpGet("get-all")]
      public async Task<IActionResult> GetUnits()
      {
         var units = await _context.Units.ToListAsync();
         return Ok(units);
      }

      [HttpPost("add")]
      public async Task<IActionResult> AddUnit(Unit unit)
      {
         _context.Units.Add(unit);
         await _context.SaveChangesAsync();

         return Ok(await _context.Units.ToListAsync());
      }

      [HttpPut("update/{id}")]
      public async Task<IActionResult> UpdateUnit([FromRoute]int id, Unit unit)
      {
         var dbUnit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);
         if (dbUnit == null)
         {
            return NotFound("Unit with the given Id doesn't exist.");
         }

         dbUnit.Title = unit.Title;
         dbUnit.Attack = unit.Attack;
         dbUnit.Defense = unit.Defense;
         dbUnit.BananaCost = unit.BananaCost;
         dbUnit.HitPoints = unit.HitPoints;

         await _context.SaveChangesAsync();

         return Ok(dbUnit);
      }

      [HttpDelete("delete/{id}")]
      public async Task<IActionResult> DeleteUnit([FromRoute] int id)
      {
         var dbUnit = await _context.Units.FirstOrDefaultAsync(u => u.Id == id);
         if (dbUnit == null)
         {
            return NotFound("Unit with the given Id doesn't exist.");
         }

         _context.Units.Remove(dbUnit);
         await _context.SaveChangesAsync();

         return Ok(await _context.Units.ToListAsync());
      }
   }
}
