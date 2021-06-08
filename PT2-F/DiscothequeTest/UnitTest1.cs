using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1;

namespace DiscothequeTest
{
    [TestClass]
    public class UnitTest1
    {
        MusiquePT2_FEntities conn = Utils.Connexion;

        [TestMethod]
        public void TestMethod2()
        {
            bool test = Utils.RegisterAbo("Test", "US2", "tus2", "mdp", 3);
            Assert.IsTrue(test);

            ABONNÉS abo = (from ab in conn.ABONNÉS
                           where ab.LOGIN_ABONNÉ == "tus2"
                           select ab).FirstOrDefault();

            Dictionary<EMPRUNTER, ABONNÉS> emprunts = Utils.ConsulterEmprunts(abo.CODE_ABONNÉ);



        }
        
    }
}
