using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shelter.Controllers
{
    public class AnimalController : Controller
    {
        // GET: AnimalController1
        public ActionResult Index()
        {
            if (!System.IO.File.Exists("AnimalList.json"))
            {
                System.IO.File.WriteAllText("AnimalList.json", "[]");
            }
            string animalsItems = System.IO.File.ReadAllText("AnimalList.json");

            List<AnimalModel> animalsList = JsonConvert.DeserializeObject<List<AnimalModel>>(animalsItems);

            if (animalsList == null)
            {
                animalsList = new();
            }
            return View(animalsList);
        }

        // GET: AnimalController1/Details/5
        public ActionResult Details(int id)
        {
            string animalsItems = System.IO.File.ReadAllText("AnimalList.json");
            List<AnimalModel> animalsList = JsonConvert.DeserializeObject<List<AnimalModel>>(animalsItems);
            AnimalModel selectedAnimal = animalsList.FirstOrDefault(a => a.Id == id);
            return View(selectedAnimal);

        }

        // GET: AnimalController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnimalController1/Create
        [HttpPost]
        public ActionResult Create(AnimalModel animal)
        {
            if (!System.IO.File.Exists("AnimalList.json"))
            {
                System.IO.File.WriteAllText("AnimalList.json", "[]");
            }

            if (!System.IO.File.Exists("IdList.json"))
            {
                System.IO.File.WriteAllText("IdList.json", "0");
            }

            int id = Int32.Parse(System.IO.File.ReadAllText("IdList.json"));
            id++;

            animal.Id = id;
            System.IO.File.WriteAllText("IdList.json", id + "");

            string animalsItems = System.IO.File.ReadAllText("AnimalList.json");
            List<AnimalModel> animalsList = JsonConvert.DeserializeObject<List<AnimalModel>>(animalsItems);

            if (animalsList == null)
            {
                animalsList = new();
            }
            animalsList.Add(animal);
            string jsonModels = JsonConvert.SerializeObject(animalsList);
            System.IO.File.WriteAllText("AnimalList.json", jsonModels);
            return RedirectToAction("Index");
          
        }

        // GET: AnimalController1/Edit/5
        public ActionResult Edit(int id)
        {
            string animalsItems = System.IO.File.ReadAllText("AnimalList.json");
            List<AnimalModel> animalsList = JsonConvert.DeserializeObject<List<AnimalModel>>(animalsItems);
            AnimalModel selectedAnimal = animalsList.FirstOrDefault(a => a.Id == id);
            return View(selectedAnimal);
        }

        // POST: AnimalController1/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AnimalModel animal)
        {
            string animalsItems = System.IO.File.ReadAllText("AnimalList.json");
            List<AnimalModel> animalsList = JsonConvert.DeserializeObject<List<AnimalModel>>(animalsItems);
            for (int i = 0; i < animalsList.Count; i++)
            {
                if (animalsList[i].Id == id)
                {
                    animalsList[i] = animal;
                    break;
                }
            }

            animalsItems = JsonConvert.SerializeObject(animalsList);
            System.IO.File.WriteAllText("AnimalList.json", animalsItems);
            return RedirectToAction("Index");
            
        }

        // GET: AnimalController1/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();

        }

        // POST: AnimalController1/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AnimalModel animal)
        {
            string animalsItems = System.IO.File.ReadAllText("AnimalList.json");
            List<AnimalModel> animalsList = JsonConvert.DeserializeObject<List<AnimalModel>>(animalsItems);
            for (int i = 0; i < animalsList.Count; i++)
            {
                if (animalsList[i].Id == id)
                {
                    animalsList[i] = animal;
                    break;
                }
            }

            animalsItems = JsonConvert.SerializeObject(animalsList);
            System.IO.File.WriteAllText("AnimalList.json", animalsItems);
            return RedirectToAction("Index");

            
           
        }
    }
}
