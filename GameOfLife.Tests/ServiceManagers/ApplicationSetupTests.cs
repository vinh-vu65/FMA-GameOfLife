using System.Collections.Generic;
using GameOfLife.Code.Enums;
using GameOfLife.Code.IO;
using GameOfLife.Code.Models.DataObjects;
using GameOfLife.Code.ServiceManagers;
using GameOfLife.Code.Services;
using NSubstitute;
using Xunit;

namespace GameOfLife.Tests.ServiceManagers;

public class ApplicationSetupTests
{
    private readonly IInput _input = Substitute.For<IInput>();
    private readonly IOutput _output = Substitute.For<IOutput>();
    private readonly ISeedReader _seedReader = Substitute.For<ISeedReader>();
    private readonly string[] _fileNames;

    public ApplicationSetupTests()
    {
        var seedFileDictionary = new Dictionary<string, string>
        {
            {"1", "testSeed.txt"},
            {"2", "hello"},
            {"3", "test"}
        };
        _seedReader.SeedFilesMenu.Returns(seedFileDictionary);
        _fileNames = new[] {"testSeed.txt", "hello", "test"};
        _seedReader.GetFilenames().Returns(_fileNames);
    }

    public struct InputExpectedOutputData
    {
        public (string seed, string gameSpeed, string generationLimit) Input;
        public (string seedFile, GameSpeed gameSpeed, int generationLimit) Expected;
    }
    
    public static IEnumerable<object[]> GetCleanInputData()
    {
        yield return new object[]
        {
            new InputExpectedOutputData
            {
                Input = ("1", "1", "45"),
                Expected = ("testSeed.txt", GameSpeed.Slow, 45)
            }
        };
        yield return new object[]
        {
            new InputExpectedOutputData
            {
                Input = ("2", "2", "1"),
                Expected = ("hello", GameSpeed.Regular, 1)
            }
        };
        yield return new object[]
        {
            new InputExpectedOutputData
            {
                Input = ("3", "4", "10"),
                Expected = ("test", GameSpeed.NoDelay, 10)
            }
        };
    }

    [Theory]
    [MemberData(nameof(GetCleanInputData))]    
    public void ApplicationSetup_ShouldSetGameSpeedAndGenerationLimitBasedOnUserInputs_WhenConstructed(InputExpectedOutputData data)
    {
        _input.Read().Returns(_ => data.Input.seed,
            _ => data.Input.gameSpeed,
            _ => data.Input.generationLimit);

        var sut = new ApplicationSetup(_input, _output, _seedReader);
        
        Assert.Equal(data.Expected.gameSpeed, sut.GameSpeed);
        Assert.Equal(data.Expected.generationLimit, sut.GenerationLimit);
    }

    [Fact]
    public void ApplicationSetup_ShouldCallSeedReaderGetFileNames_WhenUserIsChoosingSeedFileDuringConstruction()
    {
        var validInput = "1";
        _input.Read().Returns(validInput);
        
        var sut = new ApplicationSetup(_input, _output, _seedReader);

        _seedReader.Received(1).GetFilenames();
        _output.Received(1).Write(GameMessageBuilder.ChooseSeed(_fileNames));
    }

    [Theory]
    [InlineData("4")]
    [InlineData("0")]
    [InlineData("hello")]
    public void ApplicationSetup_ShouldDisplayInvalidInputMessage_WhenUserInputForSeedFileDoesNotMatchSeedFileDictionaryKey(string invalidSeedFileKey)
    {
        var validInput = "2";
        _input.Read().Returns(_ => invalidSeedFileKey,
            _ => validInput,
            _ => validInput,
            _ => validInput);
        
        var sut = new ApplicationSetup(_input, _output, _seedReader);

        _output.Received(1).Write(GameMessageBuilder.InvalidInput());
    }
    
    [Theory]
    [InlineData("5")]
    [InlineData("0")]
    [InlineData("hello")]
    public void ApplicationSetup_ShouldDisplayInvalidInputMessage_WhenUserInputForGameSpeedDoesNotMatchGameSpeedDictionaryKey(string invalidGameSpeedKey)
    {
        var validInput = "3";
        _input.Read().Returns(_ => validInput,
            _ => invalidGameSpeedKey,
            _ => validInput,
            _ => validInput);
        
        var sut = new ApplicationSetup(_input, _output, _seedReader);

        _output.Received(1).Write(GameMessageBuilder.InvalidInput());
    }
    
    [Theory]
    [InlineData("-10")]
    [InlineData("0")]
    [InlineData("hello")]
    public void ApplicationSetup_ShouldDisplayInvalidInputMessage_WhenUserInputForGenerationLimitIsNotANumberGreaterThanZero(string invalidInput)
    {
        var validInput = "3";
        _input.Read().Returns(_ => validInput,
            _ => validInput,
            _ => invalidInput,
            _ => validInput);
        
        var sut = new ApplicationSetup(_input, _output, _seedReader);

        _output.Received(1).Write(GameMessageBuilder.InvalidInput());
    }

    [Theory]
    [MemberData(nameof(GetCleanInputData))]
    public void CreateGameService_ShouldCallSeedReaderReadMethod_WhenUserInputsAreValid(InputExpectedOutputData data)
    {
        var expectedSeedFile = data.Expected.seedFile;
        _input.Read().Returns(_ => data.Input.seed,
            _ => data.Input.gameSpeed,
            _ => data.Input.generationLimit);
        var testSeed = new[]
        {
            " #  *"
        };
        _seedReader.Read(expectedSeedFile).Returns(testSeed);
        var sut = new ApplicationSetup(_input, _output, _seedReader);

        sut.CreateGameService();

        _seedReader.Received(1).Read(expectedSeedFile);
    }
    
    [Theory]
    [MemberData(nameof(GetCleanInputData))]
    public void CreateGameService_ShouldReturnGameServiceWithCurrentWorldBasedOnUserChosenSeed_WhenUserInputsAreValid(InputExpectedOutputData data)
    {
        var expectedSeedFile = data.Expected.seedFile;
        _input.Read().Returns(_ => data.Input.seed,
            _ => data.Input.gameSpeed,
            _ => data.Input.generationLimit);
        var testSeed = new[]
        {
            " #  *"
        };
        _seedReader.Read(expectedSeedFile).Returns(testSeed);
        var seedList = new List<Coordinate> {new(1, 0)};
        var sut = new ApplicationSetup(_input, _output, _seedReader);
        var expected = new GameService(seedList, new WorldAnalyser(seedList), new WorldBuilder(1, 5));

        var result = sut.CreateGameService();

        Assert.Equal(expected.CurrentWorld.Height, result.CurrentWorld.Height);
        Assert.Equal(expected.CurrentWorld.Width, result.CurrentWorld.Width);
        Assert.Equal(expected.CurrentWorld.Population[0,1].IsAlive, result.CurrentWorld.Population[0,1].IsAlive);
    }
}

