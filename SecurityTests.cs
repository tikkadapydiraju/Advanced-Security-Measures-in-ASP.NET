using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class SecurityTests
{
    [TestMethod]
    public void TestSqlInjectionPrevention()
    {
        var service = new SecurityService();
        bool result = service.ValidateUser("'; DROP TABLE Users; --", "password");
        Assert.IsFalse(result, "SQL Injection should fail");
    }

    [TestMethod]
    public void TestAuthentication()
    {
        var service = new SecurityService();
        bool result = service.ValidateUser("validUser", "validPassword");
        Assert.IsTrue(result, "Authentication with valid credentials should succeed");
    }
}
