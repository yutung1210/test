using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;

namespace WebApplication1.Services
{
    public class workflow
    {
        public String test()
        {
            
                WebReference.WorkflowServiceService ws = new WebReference.WorkflowServiceService();
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("Textbox2", "haha");
                dic.Add("Textbox3", "kaka");
                dic.Add("Textbox4", "wawa");

                string FormoId = ws.findFormOIDsOfProcess("AAA");
                string FormTemplate = ws.getFormFieldTemplate(FormoId);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(XmlReader.Create(new StringReader(FormTemplate)));
                XmlNodeList nodeList = xmlDoc.SelectSingleNode("Assistant").ChildNodes;

                foreach (XmlNode xn in nodeList)
                {
                    XmlElement xe = (XmlElement)xn;

                    if (dic.ContainsKey(xe.GetAttribute("id")))
                    {
                        xe.InnerText = dic[xe.GetAttribute("id")];
                    }
                }

                MemoryStream memStream = new MemoryStream(500);
                xmlDoc.Save(memStream);

                string result = Encoding.UTF8.GetString(memStream.ToArray());
                string pid = "";

                pid = ws.invokeProcess("AAA", "42147", "IC02", FormoId, result, "");

                return pid;
            
;        }
    }
}