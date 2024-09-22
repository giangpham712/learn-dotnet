using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace ConsoleApp.Tests;

public class AutoFixtureSampleTests
{
    [Fact]
    public void IntroductoryTest()
    {
        // Arrange
        var fixture = new Fixture();

        var expectedNumber = fixture.Create<int>();
        var sut = fixture.Create<MyTestClass>();
        
        // Act
        int result = sut.Echo(expectedNumber);
        
        // Assert
        Assert.Equal(expectedNumber, result);
    }

    [Theory, AutoData]
    public void IntroductoryTestWithTheory(int expectedNumber, MyTestClass sut)
    {
        int result = sut.Echo(expectedNumber);
        Assert.Equal(expectedNumber, result);
    }

    [Fact]
    public void TestWithMock()
    {
        var fixture = new Fixture();
        fixture.Customize(new AutoMoqCustomization());
        
        var testService = fixture.Create<ITestService>();
    }

    [Fact]
    public void TestWithObjectBuilder()
    {
        var fixture = new Fixture();
        var mc1 = fixture.Build<MyTestClass>().With(x => x.A, "A1").Create();
        var mc2 = fixture.Build<MyTestClass>().With(x => x.A, "A2").Create();
        var mc3 = fixture.Build<MyTestClass>().OmitAutoProperties().With(x => x.A, "A3").Create();

        var dto = fixture.Build<MyTestClass>().Create<MyTestClassDto>();
    }
}

public class MyTestClass
{
    public string A { get; set; }
    
    public string B { get; set; }
    
    public int Echo(int expectedNumber)
    {
        return expectedNumber;
    }
}

public record MyTestClassDto
{
    public string A { get; set; }
    
    public string B { get; set; }
}

public interface ITestService
{
    int DoSomething(MyTestClass myTestClass);
}

public class MyTestService : ITestService
{
    public int DoSomething(MyTestClass myTestClass)
    {
        return myTestClass.Echo(10);
    }
}