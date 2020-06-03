# Simple Interation Benchmark.  
Main Scene is `Assets/Benchmark/SelectorScene.scene`.  
By default there are 100.000 GameObjects with Transform which moving along (0,0,1) vector.  
Unity Editor Version is 2019.3.15f1 (59ff3e03856d)  
  
## MonoBehaviours  
![monobehaviours.png](Images/monobehaviours.png)  

Each GameObject has MonoBehaviour with Update method.  
All scripts are in `Assets/Benchmark/MonoBehaviours`.  
## Morpeh ECS  
![morpeh.png](Images/morpeh.png)  

Simple system that moving GameObject forward.  
All scripts are in `Assets/Benchmark/Morpeh`.  
Scene is on path `Assets/Benchmark/Morpeh/MorpehScene.scene`.
## Morpeh ECS + Jobs + Burst  
![morpeh_jobs.png](Images/morpeh_jobs.png)  

System that moving GameObject forward by Unity.Jobs with Burst Compiler.  
All scripts are in `Assets/Benchmark/Morpeh`.  
Scene is on path `Assets/Benchmark/Morpeh/MorpehJobScene.scene`.

### Configuration
![configuration.png](Images/configuration.png)  