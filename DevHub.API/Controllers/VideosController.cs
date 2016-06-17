using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DevHub.API.Models;
using DevHub.API.DAL.Interfaces;

namespace DevHub.API.Controllers
{
    public class VideosController : ApiController
    {
        private IVideoRepository repo;

        public VideosController(IVideoRepository repo)
        {
            this.repo = repo;
        }

        // GET: api/Videos
        public IEnumerable<Video> GetVideos()
        {
            return repo.GetAll();
        }

        // GET: api/Videos/5
        [ResponseType(typeof(Video))]
        public IHttpActionResult GetVideo(int id)
        {
            Video video = repo.GetByID(id);
            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
        }

        // PUT: api/Videos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVideo(int id, Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.Id)
            {
                return BadRequest();
            }

            repo.Update(video);

            try
            {
                repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Videos
        [ResponseType(typeof(Video))]
        public IHttpActionResult PostVideo(Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Insert(video);
            repo.Save();

            return CreatedAtRoute("DefaultApi", new { id = video.Id }, video);
        }

        // DELETE: api/Videos/5
        [ResponseType(typeof(Video))]
        public IHttpActionResult DeleteVideo(int id)
        {
            Video video = repo.GetByID(id);
            if (video == null)
            {
                return NotFound();
            }

            repo.Delete(id);
            repo.Save();

            return Ok(video);
        }

        protected override void Dispose(bool disposing)
        {
            repo.Dispose();
        }
    }
}