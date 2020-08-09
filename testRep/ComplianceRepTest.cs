using ComplianceRepository;
using ComplianceRepository.Data;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

namespace testRep.TestComplianceRepository
{
    [TestFixture]
    public class ComplianceRepTest
    {
        private RepositoryComplianceApi _rep = new RepositoryComplianceApi(Properties.Settings.Default.ApiKey, Properties.Settings.Default.UrlService);

        [Test]
        public void GetToken_GoodKey()
        {
            var m = GetMethod("GetToken");
            var token = m.Invoke(_rep, new object[] { Properties.Settings.Default.ApiKey });

            Assert.IsNotNull(token);
        }

        [Test]
        public void GetToken_NotGoodKey()
        {
            var m = GetMethod("GetToken");
            var token = m.Invoke(_rep, new object[] { "123" });

            Assert.IsNull(token);
        }

        [Test]
        public void GetPeoples_GoodRequest()
        {
            var m = GetMethod("GetToken");
            var token = m.Invoke(_rep, new object[] { Properties.Settings.Default.ApiKey });

            m = GetMethod("GetPeoples");
            var query = "";
            var peoples = (Peoples)m.Invoke(_rep, new object[] { token, query });

            Assert.IsTrue(peoples.Entities.Entity.Count == int.Parse(peoples.System_info.Count));
            Assert.IsTrue(peoples.Entities.Entity.Any());
        }

        [Test]
        public void GetPeoples_NotGoodRequest()
        {
            var m = GetMethod("GetToken");
            var token = m.Invoke(_rep, new object[] { Properties.Settings.Default.ApiKey });

            m = GetMethod("GetPeoples");
            var query = $"&since=1111111111111";
            var peoples = (Peoples)m.Invoke(_rep, new object[] { token, query });

            Assert.IsFalse(peoples.Entities.Entity.Any());
        }

        private MethodInfo GetMethod(string methodName)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                Assert.Fail("methodName cannot be null or whitespace");

            var method = _rep.GetType().GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);

            if (method == null)
                Assert.Fail(string.Format("{0} method not found", methodName));

            return method;
        }
    }
}