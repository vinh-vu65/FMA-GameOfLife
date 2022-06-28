using GameOfLife.Code.Controller;
using GameOfLife.Code.IO;
using GameOfLife.Code.Service;

var reader = new FileReader(args[0]);
var renderer = new ConsoleRenderer();
var writer = new ConsoleWriter();
var seed = new SeedFileParser(reader);
var gameService = new GameService(seed, new WorldAnalyser(), new WorldBuilder(seed.Height, seed.Width));

var app = new Application(writer, gameService, renderer);

app.Run(args.Length > 1 ? int.Parse(args[1]) : 1000);