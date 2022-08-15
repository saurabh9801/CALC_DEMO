using CALC_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CALC_DEMO.Controllers
{
    public class CalculatorCrudController : ApiController
    {
        public IHttpActionResult GetHistoryById(int id)
        {
            CalcViewModel calc = null;

            using (var ctx = new CALCDBEntities())
            {
                calc = ctx.CALCULATOR_TBL.Include("result")
                    .Where(s => s.IDCLC == id)
                    .Select(s => new CalcViewModel()
                    {
                        CID = s.IDCLC,
                        Fst_Number = (int)s.FST_NUMBER,
                        Snd_Number = (int)s.SND_NUMBER,
                        Operator = s.OPERATOR,
                        Result = (int)s.RESULT,
                        CreatedOn = (DateTime)s.CREATED_ON

                    }).FirstOrDefault<CalcViewModel>();
            }

            if (calc == null)
            {
                return NotFound();
            }

            return Ok(calc);
        }


        public IHttpActionResult PostCalcHistory(CalcViewModel calcViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");

            using (var ctx = new CALCDBEntities())
            {
                ctx.CALCULATOR_TBL.Add(new CALCULATOR_TBL()
                {
                    FST_NUMBER = calcViewModel.Fst_Number,
                    SND_NUMBER = calcViewModel.Snd_Number,
                    OPERATOR = calcViewModel.Operator,
                    RESULT = calcViewModel.Result,
                    CREATED_ON = calcViewModel.CreatedOn
                });
                ctx.SaveChanges();
            }
            return Ok(calcViewModel.Result);
        }
    }
}
