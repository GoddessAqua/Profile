using NUnit.Framework;
using Profile;

namespace Tests
{
    [TestFixture]
    public class ProfileTests
    {
        [Test]
        public void IsProfileWithoutPhoneNullOrEmpty()
        {
            var userProfile = new AuthData
            {
                Phone = "",
                FirstName = "User",
                LastName = "First",
                BirthDay = "12.12.2012",
                DocumentsData = new DocumentData
                {
                    DocumentNumber = "1234",
                    DocumetSeries = "245555"
                }
            };

            var isProfileNullOrEmpty = AuthData.IsProfileNullOrEmpty(userProfile);

            Assert.That(isProfileNullOrEmpty, Is.EqualTo(true));
        }

        [Test]
        public void IsProfileWithoutFirstNameNullOrEmpty()
        {
            var userProfile = new AuthData
            {
                Phone = "753468246",
                FirstName = null,
                LastName = "First",
                BirthDay = "12.12.2012",
                DocumentsData = new DocumentData
                {
                    DocumentNumber = "1234",
                    DocumetSeries = "245555"
                }
            };

            var isProfileNullOrEmpty = AuthData.IsProfileNullOrEmpty(userProfile);

            Assert.That(isProfileNullOrEmpty, Is.EqualTo(true));
        }

        [Test]
        public void IsProfileWithoutDocumetSeriesOrEmpty()
        {
            var userProfile = new AuthData
            {
                Phone = "12345678910",
                FirstName = "User",
                LastName = "First",
                BirthDay = "12.12.2012",
                DocumentsData = new DocumentData
                {
                    DocumentNumber = "1234",
                    DocumetSeries = null
                }
            };

            var isProfileNullOrEmpty = AuthData.IsProfileNullOrEmpty(userProfile);

            Assert.That(isProfileNullOrEmpty, Is.EqualTo(true));
        }

        [Test]
        public void IsProfileFull()
        {
            var userProfile = new AuthData
            {
                Phone = "12345678910",
                FirstName = "User",
                LastName = "First",
                BirthDay = "12.12.2012",
                DocumentsData = new DocumentData
                {
                    DocumentNumber = "1234",
                    DocumetSeries = "242566"
                }
            };

            var isProfileNullOrEmpty = AuthData.IsProfileNullOrEmpty(userProfile); // should be not null or empty
                                                                                   // due to this fact method returns false

            Assert.That(isProfileNullOrEmpty, Is.EqualTo(false)); //expected false
        }
    }
}