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
        [TestMethod]
        public void TestAjoutAbonnée()
        {
            var bdResult = (from data in Utils.Connexion.ABONNÉS
                           where data.LOGIN_ABONNÉ.Equals("TestRegister")
                           select data.CODE_ABONNÉ);

            //On passse si l'abonné TestRegister n'existe pas
            if(bdResult.Count() != 0)
            {
                //On supprime l'abonné si il existe 
                var emprunts = (from e in Utils.Connexion.EMPRUNTER
                                where e.CODE_ABONNÉ == bdResult.FirstOrDefault()
                                select e);
                Utils.Connexion.EMPRUNTER.RemoveRange(emprunts);
                Utils.Connexion.ABONNÉS.Remove(Utils.GetABONNÉ(bdResult.FirstOrDefault()));

                //Assert.IsFalse(Utils.GetABONNÉ(bdResult.CODE_ABONNÉ).LOGIN_ABONNÉ.Equals(bdResult.LOGIN_ABONNÉ));
                Assert.IsFalse(Utils.GetABONNÉ(bdResult.FirstOrDefault()).CODE_ABONNÉ.Equals(bdResult.FirstOrDefault()));
            }

            //On ajoute un abonné
            bool t = Utils.RegisterAbo("Test", "Register", "TestRegister", "123456", 1);

            //On regarde si il a bien etait cree
            Assert.IsTrue(t);

            var result = from data in Utils.Connexion.ABONNÉS
                       where data.LOGIN_ABONNÉ.Equals("TestRegister")
                       select data.CODE_ABONNÉ;

            //On verifie avec la base de données si il existe bien
            Assert.IsTrue(Utils.GetABONNÉ(result.FirstOrDefault()).LOGIN_ABONNÉ.Equals("TestRegister"));
        }
        
    }
}
