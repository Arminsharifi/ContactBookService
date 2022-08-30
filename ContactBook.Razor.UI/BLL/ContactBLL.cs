using ContactBook.Razor.UI.Models;
using Newtonsoft.Json;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ContactBook.Razor.UI.BLL
{
    internal class ContactBLL
    {
        internal List<Contact> GetAll()
        {
            string Json = "";
            WebRequest request = WebRequest.Create("https://localhost:7230/api/Contacts");
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                Json = new StreamReader(responseStream, Encoding.UTF8).ReadToEnd();
            }
            List<Contact> lstContact = JsonConvert.DeserializeObject<List<Contact>>(Json);
            if (lstContact != null && lstContact.Count > 0) return lstContact;
            else return new List<Contact>();
        }

        internal Contact Get(int Id)
        {
            string Json = "";
            WebRequest request = WebRequest.Create("https://localhost:7230/api/Contacts/" + Id);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                Json = new StreamReader(responseStream, Encoding.UTF8).ReadToEnd();
            }
            Contact contact = JsonConvert.DeserializeObject<Contact>(Json);
            if (contact != null) return contact;
            else return new Contact();
        }

        internal bool Delete(int Id)
        {
            WebRequest request = WebRequest.Create("https://localhost:7230/api/Contacts/" + Id);
            request.Method = "DELETE";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }

        internal bool Add(Contact contact)
        {
            WebRequest request = WebRequest.Create("https://localhost:7230/api/Contacts/");
            request.Method = "POST";
            request.ContentType = "application/json";
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(contact);
                streamWriter.Write(json);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }
        
        internal bool Update(Contact contact)
        {
            WebRequest request = WebRequest.Create("https://localhost:7230/api/Contacts/");
            request.Method = "PUT";
            request.ContentType = "application/json";
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(contact);
                streamWriter.Write(json);
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else return false;
        }
    }
}
