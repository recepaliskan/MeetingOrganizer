using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MeetingOrganizer.Models;

namespace MeetingOrganizer.Controllers
{
    public class ParticipantController : Controller
    {
        private MeetingOrganizerDBEntities db = new MeetingOrganizerDBEntities();

       
        public ActionResult Index()
        {
            return View(db.tbl_Participant.ToList());
        }

        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Participant Participant)
        {
            db.tbl_Participant.Add(Participant);
            db.SaveChanges();
            return RedirectToAction("Index","Meeting");
        }

        
    }
}
