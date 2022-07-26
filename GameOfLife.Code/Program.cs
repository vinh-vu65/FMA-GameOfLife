using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;

var seedReader = new SeedFileReader();
var renderer = new ConsoleWorldRenderer();
var writer = new ConsoleOutput(renderer);
var inputReader = new ConsoleInput();
var setup = new ApplicationSetup(inputReader, writer, seedReader);

var gameService = setup.CreateGameService();
var app = new Application(writer, gameService, setup.GameSpeed, setup.GenerationLimit);

app.Run();