﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lexicon_LMS.Models;

namespace Lexicon_LMS
{
    public class ActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: 
        public ActionResult Index(int? id)
        {
            var ActiveUser = db.Users.Where(u => u.UserName == User.Identity.Name.ToString()).ToList().FirstOrDefault();

            if (id != null)
            {
                ViewBag.ActualCourseId = id;
                if (User.IsInRole("Teacher"))
                {
                    var activities = db.Activities.Where(a => a.CourseId == id).OrderBy(a => a.StartDate);
                    ViewBag.GroupId = activities.FirstOrDefault().Course.GroupId;
                    ViewBag.GroupName = activities.FirstOrDefault().Course.Group.Name;
                    ViewBag.CourseName = db.Courses.Where(c => c.CourseId == id).FirstOrDefault().Name;
                    return View(activities.ToList());
                    

                }
                else
                {
                    var ActiveGroup = db.Groups.Where(g => g.GroupId == ActiveUser.GroupId);
                    var ActiveCourse = db.Courses.Where(g => g.GroupId == ActiveUser.GroupId);
                    ViewBag.GroupId = ActiveGroup.FirstOrDefault().GroupId;
                    ViewBag.GroupName = ActiveGroup.FirstOrDefault().Name;
                    ViewBag.CourseName = ActiveCourse.FirstOrDefault().Name;
                    var activities = db.Activities.Where(a => a.CourseId == id);
                    return View(activities.ToList());
                }
            }

            else
            {
                return RedirectToAction("Index", "Home");
            }


            //var courses = db.Courses.Where(c => c.GroupId == ActiveUser.GroupId);
            //var activities = db.Activities.Where(a => a.CourseId == AKTUELL_KURS_ID).ToList();


        }

        //// GET: Activities
        //public ActionResult Index()
        //{
        //    var activities = db.Activities.Include(a => a.Course);
        //    return View(activities.ToList());
        //}

        // GET: Activities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // GET: Activities/Create
        public ActionResult Create(int? courseId = null)
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name");
            ViewBag.ActualCourseId = courseId;
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityId,CourseId,Type,Name,Teacher,Description,StartDate,EndDate")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Activities.Add(activity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", activity.CourseId);
            return View(activity);
        }

        // GET: Activities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", activity.CourseId);
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityId,CourseId,Type,Name,Teacher,Description,StartDate,EndDate")] Activity activity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", activity.CourseId);
            return View(activity);
        }

        // GET: Activities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity activity = db.Activities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity activity = db.Activities.Find(id);
            db.Activities.Remove(activity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
