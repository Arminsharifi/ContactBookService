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
            contact.Id = GetSessionContact().Id;
            if (ModelState.IsValid)
            {
                if (new ContactBLL().Update(contact)) return RedirectToPage("Index");
            }
            return Page();
        }

        private Contact GetSessionContact()
        {
            string? ContactJson = HttpContext.Session.GetString("Contact");
            if (string.IsNullOrWhiteSpace(ContactJson))
            {
                return new Contact();
            }
            else return JsonConvert.DeserializeObject<Contact>(ContactJson);
        }

        private void SaveSessionContact(Contact contact)
        {
            HttpContext.Session.SetString("Contact", JsonConvert.SerializeObject(contact));
        }
    }
}
