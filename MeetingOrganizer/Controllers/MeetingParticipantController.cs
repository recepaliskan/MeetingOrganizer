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
    public class MeetingParticipantController : Controller
    {
        private MeetingOrganizerDBEntities db = new MeetingOrganizerDBEntities();


        [HttpPost]
        public ActionResult Detail(int? id)
        {

            return PartialView(db.tbl_MeetingParticipant.Where(x => x.MeetingId == id).ToList());
        }

        public ActionResult Add(int id)
        {
            var Liste = db.tbl_MeetingParticipant.Where(x=> x.MeetingId == id).Select(y=> y.ParticipantId).ToArray();

            List<SelectListItem> participantsList = (from participant in db.tbl_Participant.Where(x=> !Liste.Contains(x.ID)).ToList()
                                                     select new SelectListItem()
                                                     {
                                                         Text = participant.Name + " " + participant.Surname,
                                                         Value = participant.ID.ToString()
                                                     }).ToList();
            ViewBag.Participants = participantsList;    

            return PartialView();
        }

        [HttpPost]
        public ActionResult Add(tbl_MeetingParticipant AddParticipant, int id)
        {
            try
            {
                AddParticipant.MeetingId = id;


                db.tbl_MeetingParticipant.Add(AddParticipant);
                db.SaveChanges();

                return RedirectToAction("Index", "Meeting");

            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }




    }
}
