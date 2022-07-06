using GameOfLife.Code.Enums;
using GameOfLife.Code.IO;
using GameOfLife.Code.Service;

namespace GameOfLife.Code.Controller;

public class ApplicationSetup
{
    private readonly IInput _input;
    private readonly IOutput _output;
    private readonly ISeedReader _seedReader;
    private string _seedFile = null!;
    public GameSpeed GameSpeed { get; private set; }
    public int GenerationLimit { get; private set; }

    public ApplicationSetup(IInput input, IOutput output, ISeedReader seedReader)
    {
        _input = input;
        _output = output;
        _seedReader = seedReader;
        RunSetup();
    }

    public IGameService CreateGameService()
    {
        var seedParser = new SeedFileParser(_seedReader, _seedFile);
        var seed = seedParser.ParseSeed();
        return new GameService(seed, new WorldAnalyser(seed), new WorldBuilder(seedParser.Height, seedParser.Width));
    }
    
    private void RunSetup()
    {
        _output.Reset();
        _output.Write(GameMessageBuilder.StartupMessage());
        SetSeedFile();
        SetGameSpeed();
        SetGenerationLimit();
    }
    
    private void SetSeedFile()
    {
        var seedFileNames = _seedReader.GetFilenames();
        _output.Write(GameMessageBuilder.ChooseSeed(seedFileNames));
        
        bool isValid;
        string fileName;
        do
        {
            var userChoice = _input.Read();
            isValid = _seedReader.SeedFilesMenu.TryGetValue(userChoice, out fileName!);
            if (!isValid) _output.Write(GameMessageBuilder.InvalidInput());
        } while (!isValid);

        _seedFile = fileName;
    }
    
    private void SetGameSpeed()
    {
        var gameSpeedMenu = new Dictionary<string, GameSpeed>
        {
            {"1", GameSpeed.Slow},
            {"2", GameSpeed.Regular},
            {"3", GameSpeed.Fast},
            {"4", GameSpeed.NoDelay}
        };
        
        _output.Write(GameMessageBuilder.ChooseSpeed());
        
        bool isValid;
        GameSpeed gameSpeed;
        do
        {
            var userInput = _input.Read();
            isValid = gameSpeedMenu.TryGetValue(userInput, out gameSpeed);
            if (!isValid) _output.Write(GameMessageBuilder.InvalidInput());
        } while (!isValid);

        GameSpeed = gameSpeed;
    }
    
    private void SetGenerationLimit()
    {
        _output.Write(GameMessageBuilder.ChooseRepetitions());

        bool isValid;
        int generationLimit;

        do
        {
            var userInput = _input.Read();
            isValid = int.TryParse(userInput, out generationLimit) && generationLimit > 0;
            if (!isValid) _output.Write(GameMessageBuilder.InvalidInput());
        } while (!isValid);

        GenerationLimit = generationLimit;
    }
}