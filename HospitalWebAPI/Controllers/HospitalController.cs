using HospitalWebAPI.DbContexts;
using HospitalWebAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalWebAPI.Controllers
{
    [ApiController]
    [Route("/api/hospital")]
    public class HospitalController : ControllerBase
    {
        private readonly HospitalContext hospitalContext;

        public HospitalController(HospitalContext hospitalContext)
        {
            this.hospitalContext = hospitalContext;
        }

        [HttpGet]
        public IActionResult GetAllHospitals ()
        {
            var hospitals = hospitalContext.Hospital.ToList();
            return Ok(hospitals);
        }

        [HttpGet("{hospitalId}")]
        public IActionResult GetHospitalById (int hospitalId)
        {
            var hospitals = hospitalContext.Hospital.Find(hospitalId);
            return Ok(hospitals);
        }

        [HttpPost]
        public IActionResult CreateHospital(Hospital hospitalData)
        {
            hospitalContext.Hospital.Add(hospitalData);
            hospitalContext.SaveChanges();
            return Ok(hospitalData);
        }

        [HttpDelete("{hospitalId}")]
        public IActionResult DeletHospital(int hospitalId)
        {
            var hospital = hospitalContext.Hospital.Find(hospitalId);
            if (hospital == null)
            {
                return NotFound("this hospital not found");
            }
            hospitalContext.Hospital.Remove(hospital);
            hospitalContext.SaveChanges();
            return Ok(hospital);
        }
        [HttpPut("{hospitalId}")]
        public IActionResult UpdateHospital (Hospital hospitalInfo)
        {
            var hospital = hospitalContext.Hospital.Find(hospitalInfo.Id);
            if (hospital == null)
            {
                return NotFound("this Hospital not found");
            }
            hospital.HospitalName = hospitalInfo.HospitalName;
            hospital.icu = hospitalInfo.icu;
            hospital.icuID = hospitalInfo.icuID;
            hospital.patients = hospitalInfo.patients;
            hospitalContext.Entry(hospital).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            hospitalContext.SaveChanges();
            return Ok(hospital);
        }




    }
}
