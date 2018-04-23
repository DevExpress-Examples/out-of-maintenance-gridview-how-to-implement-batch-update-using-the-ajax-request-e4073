using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example.Models;
using System.Reflection;
using System.ComponentModel;
using Q329588.Models;

namespace Example.Controllers {
    public class HomeController : Controller {
        private String SessionKey = "Some key";

        public ActionResult Index() {
            ViewBag.Message = "Welcome to DevExpress Extensions for ASP.NET MVC!";

            return View();
        }

        public ActionResult GridViewPartial() {
            return PartialView("GridViewPartial", GetList);
        }

        public ActionResult UpdateValue(ChangedDataItems[] changedValues) {
            /* some delay */
            System.Threading.Thread.Sleep(1000);

			String status = null;
			foreach (ChangedDataItems dataItem in changedValues) {
				MyItem item = GetList.First(i => i.Id == dataItem.key);

				/* some way to set a propery */
				PropertyInfo info = item.GetType().GetProperty(dataItem.field, BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);


				if (info.CanWrite) 
					info.SetValue(item, TypeDescriptor.GetConverter(info.PropertyType).ConvertFromString(dataItem.value), null);									
				else {
					status = "Updating cannot be performed over a readonly field";
					break;
				}

				
			}
			if (status == null)
				status = "All fields successfully updated";
			return Content(status);			
        }

        public IList<MyItem> GetList {
            get {
                List<MyItem> itemList = null;

                if (Session[SessionKey] == null) {
                    itemList = new List<MyItem> {
                        new MyItem { Id = 1, Text = "Text1", Item = 1},
                        new MyItem { Id = 2, Text = "Text2", Item = 2},
                        new MyItem { Id = 3, Text = "Text3", Item = 1},
                        new MyItem { Id = 4, Text = "Text4", Item = 2}
                    };

                    Session[SessionKey] = itemList;
                }

                return (IList<MyItem>)Session[SessionKey];
            }
            set {
                Session[SessionKey] = value;
            }
        }
    }
}
