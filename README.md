# Conway's Game Of Life

A classic kata and seemingly a rite of passage for all protege developers.

You can read all about it here:

https://github.com/MYOB-Technology/General_Developer/blob/main/katas/kata-conways-game-of-life/kata-conways-game-of-life.md

### Additional requirements
I added an additional requirement to the program which was to stop the simulation when the world has stabilised.

The world is considered stabilised when the next generation of alive cells is the same as the current generation's collection of alive cells.

## Getting started
Ensure you have .NET 6 installed, which you can find here:

https://dotnet.microsoft.com/en-us/download/dotnet/6.0

Clone the repository to your local machine and cd into the GameOfLife.Code project folder. 

```
cd GameOfLife.Code
```

From there you can run the project with:

```
dotnet run
```

## Seeds
The program will interpret any file in the <code>Seeds</code> sub-folder in <code>GameOfLife.Code</code> as a seed file. 
Please ensure it is a <code>.txt</code> file.

If you would like to change the folder where seeds are read from, you can do this by editing the <code>app.config</code> file. Change the value for the <code>seedsFolder</code> key to your desired folder name.

Please ensure this folder is located within the <code>GameOfLife.Code</code> directory.

### Creating your own seed
You can create your own seed by creating a new <code>.txt</code> file in the <code>Seeds</code> folder.

You can denote any alive cell with a <code>#</code> and any other character besides <code>*</code> as a dead cell.

You will need to put an asterisk <code>*</code> in the bottom right corner of your world to set your world's dimensions

### Example seeds

#### Valid seed
```
    ##
   ####
    ##
     
             *
```

#### Invalid seeds
```


      #####
      
      *
```
Alive cells go beyond bottom right corner of the <code>*</code>

```

## ##
## ##


         *
         
 #
```
<code>*</code> not found in last line of the seed

### Seeds Menu
Once you have created your seed, your seed file will automatically populate in the Seed Files Menu when the program is run. Please select your seed by entering the corresponding number and follow the prompts for simulation speed and repetition count to begin the program.

Happy simulating!
