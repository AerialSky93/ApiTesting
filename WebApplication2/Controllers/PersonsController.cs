﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Sample.Web.Api.Models;

namespace Sample.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase 
    {
        IEnumerable<Person> persons = new List<Person>() {
            new Person() { Name = "Nancy Davolio", DOB = DateTime.Parse("1948-12-08"), Email = "nancy.davolio@test.com" },
            new Person() { Name = "Andrew Fuller", DOB = DateTime.Parse("1952-02-19"), Email = "andrew.fuller@test.com" },
            new Person() { Name = "Janet Leverling", DOB = DateTime.Parse("1963-08-30"), Email = "janet.leverling@test.com" },
            new Person() { Name = "Margaret Peacock", DOB = DateTime.Parse("1937-09-19"), Email = "margaret.peacock@test.com" },
            new Person() { Name = "Steven Buchanan", DOB = DateTime.Parse("1955-03-04"), Email = "steven.buchanan@test.com" },
            new Person() { Name = "Michael Suyama", DOB = DateTime.Parse("1963-07-02"), Email = "michael.suyama@test.com" },
            new Person() { Name = "Robert King", DOB = DateTime.Parse("1960-05-29"), Email = "robert.king@test.com" },
            new Person() { Name = "Laura Callahan", DOB = DateTime.Parse("1958-01-09"), Email = "laura.callahan@test.com" },
            new Person() { Name = "Anne Dodsworth", DOB = DateTime.Parse("1966-01-27"), Email = "anne.dodsworth@test.com" }
            };



        // GET api/values  
        [HttpGet]
        public ActionResult<IEnumerable<Person>> Get([FromQuery] PageModel filter)
        {
            var test = persons.Paginate(filter);
            return Ok(test);
        }
    }
}

