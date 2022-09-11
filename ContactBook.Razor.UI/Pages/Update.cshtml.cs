using ContactBook.Razor.UI.BLL;
using ContactBook.Razor.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ContactBook.Razor.UI.Pages
{
    public class UpdateModel : PageModel
    {
        public Contact contact = new Contact();

        public void OnGet(int Id)
        {
            contact = new ContactBLL().Get(Id);
            SaveSessionContact(contact);
        }

        public IActionResult OnPost(Contact contact)
        {
            contact.Id = HttpContext.Session.GetJson<Contact>("Contact").Id;
            if (ModelState.IsValid)
            {
                if (new ContactBLL().Update(contact)) return RedirectToPage("Index");
            }
            return Page();
        }

        private void SaveSessionContact(Contact contact)
        {
            HttpContext.Session.SetJson("Contact", contact);
        }
    }
}
