using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;

var seedsFolderName = "Seeds";
var seedReader = new SeedFileReader(seedsFolderName);
var renderer = new ConsoleWorldRenderer();
var writer = new ConsoleOutput(renderer);
var inputReader = new ConsoleInput();
var setup = new ApplicationSetup(inputReader, writer, seedReader);

var gameService = setup.CreateGameService();
var app = new Application(writer, gameService, setup.GameSpeed, setup.GenerationLimit);

app.Run();