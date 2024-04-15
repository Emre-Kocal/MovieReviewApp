using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieReviewApp.Areas.Admin.Dtos.Actor;
using MovieReviewApp.Areas.Admin.Interfaces;
using MovieReviewApp.Areas.Admin.Mappers;
using MovieReviewApp.Models;

namespace MovieReviewApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ActorController : Controller
    {
        private readonly IActorRepository _actorRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActorController(IActorRepository actorRepository, IWebHostEnvironment webHostEnvironment)
        {
            _actorRepository = actorRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Actors()
        {
            var list = await _actorRepository.GetAllAsync();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateActorDto actorAddDto, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
                return View();
            if (imageFile != null && imageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img/Actor");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                actorAddDto.Image = uniqueFileName;
            }
            await _actorRepository.CreateAsync(actorAddDto);
            return RedirectToAction("Actors", "Actor", new { area = "Admin" });
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var actor = await _actorRepository.GetByIdAsync(id);

            if (actor == null)
            {
                //return error
            }

            return View(actor.ActorToUpdateActorDto());
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateActorDto actor, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            var existingActor = await _actorRepository.GetByIdAsync(actor.Id);
            //saving existing image
            if (actor.Image.IsNullOrEmpty() && !existingActor.Image.IsNullOrEmpty())
            {
                actor.Image = existingActor.Image;
            }
            if (imageFile != null && imageFile.Length > 0)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img/Actor");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }
                actor.Image = uniqueFileName;
                //removing old picture
                if (!string.IsNullOrEmpty(existingActor.Image)){
                    string oldFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/Actor", existingActor.Image);

                    if (System.IO.File.Exists(oldFilePath))
                        System.IO.File.Delete(oldFilePath);
                }
            }

            var model = await _actorRepository.UpdateAsync(actor);

            if (model == null)
            {
                ModelState.AddModelError("", "Error while updating actor. Please try again.");
                return View(actor);
            }

            return RedirectToAction("Actors", "Actor", new { area = "Admin" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _actorRepository.DeleteAsync(id);
            if (model == null)
            {
                //return error
            }
            if (!string.IsNullOrEmpty(model.Image))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "img/Actor", model.Image);

                if (System.IO.File.Exists(filePath))
                    System.IO.File.Delete(filePath);
            }
            return RedirectToAction("Actors", "Actor", new { area = "Admin" });
        }
    }
}
