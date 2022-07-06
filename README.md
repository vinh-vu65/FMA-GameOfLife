# Conway's Game Of Life

A classic kata and seemingly a rite of passage for all protege developers.

You can read all about it here:

https://github.com/MYOB-Technology/General_Developer/blob/main/katas/kata-conways-game-of-life/kata-conways-game-of-life.md 

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


Happy simulating!
