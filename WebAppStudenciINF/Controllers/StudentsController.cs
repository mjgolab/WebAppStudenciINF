using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAppStudenciINF.Models;

namespace WebAppStudenciINF.Controllers
{
    public class StudentsController : ApiController
    {
        private WebAppStudenciINFContext db = new WebAppStudenciINFContext();

        // GET: api/Students
        public IQueryable<StudentDTO> GetStudents()
        {
            var student = from s in db.Students
                          select new StudentDTO()
                          {
                              ID = s.ID,
                              Name = s.Name,
                              LastName = s.LastName
                          };

            return student;
        }

        // GET: api/Students/5
        [ResponseType(typeof(StudentDetailsDTO))]
        public async Task<IHttpActionResult> GetStudent(int id)
        {
            var student = await db.Students.Include(s => s.ID).Select(s => new StudentDetailsDTO()
            {
                ID = s.ID,
                Name = s.Name,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                SID = s.SID,
                Course = s.Course,
                GroupName = s.GroupName,
                Specialty = s.Specialty
            }).SingleOrDefaultAsync(s => s.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Students
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            await db.SaveChangesAsync();

            var dto = new StudentDTO()
            {
                ID = student.ID,
                Name = student.Name,
                LastName = student.LastName
            };

            return CreatedAtRoute("DefaultApi", new { id = student.ID }, student);
        }

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public async Task<IHttpActionResult> DeleteStudent(int id)
        {
            Student student = await db.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            await db.SaveChangesAsync();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}