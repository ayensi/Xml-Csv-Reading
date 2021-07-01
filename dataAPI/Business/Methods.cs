using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;

namespace dataAPI.Business
{
    public class Methods
    {
        public string ChooseClassWithCodes(string methodname, int x)
        {
            int[] ids = new int[] { x };
            object[] array = (from i in ids select i).Cast<object>().ToArray();
            var defaultdatasource = WebConfigurationManager.AppSettings["DefaultDataSource"];
            Type type = Type.GetType("dataAPI.Business." + defaultdatasource);
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodname);
            var json = methodInfo.Invoke(obj, array).ToString();
            return json;
        }
        public string ChooseClassWithNames(string methodname, string x)
        {
            string[] ids = new string[] { x };
            object[] array = (from i in ids select i).Cast<object>().ToArray();
            var defaultdatasource = WebConfigurationManager.AppSettings["DefaultDataSource"];
            Type type = Type.GetType("dataAPI.Business." + defaultdatasource);
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodname);
            var json = methodInfo.Invoke(obj, array).ToString();
            return json;
        }
        public string ChooseClass(string methodname)
        {
            var defaultdatasource = WebConfigurationManager.AppSettings["DefaultDataSource"];
            Type type = Type.GetType("dataAPI.Business." + defaultdatasource);
            Object obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod(methodname);
            var json = methodInfo.Invoke(obj, null).ToString();
            return json;
        }
        public void ChangeDefaultDataSource(string datasource)
        {
            ConfigurationManager.AppSettings.Set("DefaultDataSource", datasource);
        }
    }
}