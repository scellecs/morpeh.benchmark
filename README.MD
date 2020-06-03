# Simple Interation Benchmark.  
Main Scene is `Assets/Benchmark/SelectorScene.scene`.  
By default 100.000 GameObjects with Transform which moving along (0,0,1) vector.  
  
## MonoBehaviours  
<img align="right" width="356px" height="400px" src="Images/monobehaviours.png">  

Each GameObject has MonoBehaviour with Update method.  
All scripts in `Assets/Benchmark/MonoBehaviours`.  
## Morpeh ECS  
<img align="right" width="356px" height="400px" src="Images/morpeh.png">  

Simple system that moving GameObject forward.  
All scripts in `Assets/Benchmark/Morpeh`.  
Scene on path `Assets/Benchmark/Morpeh/MorpehScene.scene`.
## Morpeh ECS + Jobs + Burst  
<img align="right" width="356px" height="400px" src="Images/morpeh_jobs.png">  

System that moving GameObject forward by Unity.Jobs with Burst Compiler.  
All scripts in `Assets/Benchmark/Morpeh`.  
Scene on path `Assets/Benchmark/Morpeh/MorpehJobScene.scene`.

### Configuration
![configuration.png](Images/configuration.png)  