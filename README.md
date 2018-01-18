# Dan Miner Tycoon

Enclosed is my clone of Idle Miner Tycoon, developed in Unity 2017.3 over two days. The following document gives an overview of the project's structure, and some notes on implementation details. This will mainly describe the C# code, and not the structure of the Unity scene and assets.

## Project Structure

The structure of the mining system in Dan Miner Tycoon is best described as a series of nested `Pipeline` objects.

A `Pipeline` describes a class representing a system with a number of sources containing resources, a number of workers to extract these resources, a sink to deposit the resources in, and a manager to oversee them. Each `Pipeline` also serves as a source to a parent `Pipeline`. `Pipeline` is an abstract class with three implementations: `Tunnel`, `Mine`, and `Depot`, which each have some domain-specific overrides and extra functionality.

![Nested Pipelines](nested_pipelines.png)

A pipeline has several values which affect the efficiency of its workers, stored in a class called `PipelineStatus`, which is also responsible for upgrades to this efficiency. It calculates a worker's speed and capacity and the cost to upgrade based on its current level, which can be upgraded if the player has sufficient cash (stored in a `CashStore` object discussed below).

A pipeline has multiple `Worker` objects (more than one should only come into play in the Tunnel and Depot pipelines). Workers are very simple - when activated, they visit all the sources in their pipeline (again, more than one source should come into play in the Mine pipeline), gather from these sources up to their maximum load, and once they have either reached their capacity or visited all their sources, they deposit their load in the pipeline's sink. A simple `Manager` object exists in the pipeline and if enabled, simply re-engages `Worker` objects once their

Sources and sinks are both implementations of the abstract class `Endpoint`, which gives them a method to be accessed by a worker, and connects to a `Store` of resources. When `Sink.Access` is called, a worker empties their carrying load and adds it to the attached `Store`. When `Source.Access` is called, a worker extracts the maximum amount available from the `Store` that they can carry. There is one exception to this in the source of the mines, which uses a subclass of `Source` called `UnlimitedSource`, which does not remove resource from any store and simply gives the `Worker` the maximum load they can carry.

The `Store` object contains a private `Quantity` value and two methods to access it, `Deposit` and `Extract`. `Deposit` simply adds a value to the existing quantity, and `Extract` removes the provided amount, to a minimum of zero. However, `Store` has one subclass, `CashStore`, used as the `Store` for the depot's `Sink`, which overrides `Extract` to throw an exception before it proceeds if the new quantity would otherwise go below zero.

The project also contains