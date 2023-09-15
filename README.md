# Snowflake ID Generator for C#

## Overview
This library provides a simple and thread-safe Snowflake ID generator for C#. Snowflake IDs are unique, distributed, time-sortable identifiers. This is particularly useful for distributed systems where you cannot guarantee uniqueness of IDs generated independently at multiple locations.

## Features
	* Thread-safe: Generate IDS concurently without conflicts.
	* Customizable: Set custom worket and data center IDs.
	* Time-sortable: IDs can be sorted by the time of teir generation.

## Installation
You can download the package from NuGet:
```mathematica
Install-package SnowflakeIdGeneratorForCsharp
```

Or add it directly to your project file:
```mathematica
<PackageReference Include="SnowflakeIdGeneratorForCsharp" Version="x.x.x" />
```

## Usage
```csharp
var idGenerator = new SnowflakeIdGenerator(1, 1);
long uniqueId = idGenerator.CreateId();
```

## Configuration
You can customize worker and data center IDs during the initialization of the `SnowflakeIdGenerator`:
```csharp
var idGenerator1 = new SnowflakeIdGenerator(1, 1); // for the first server
var idGenerator2 = new SnowflakeIdGenerator(2, 1); // for the second server
var idGenerator3 = new SnowflakeIdGenerator(1, 2); // for a server in a different data center
```

## Contributing
If you find any issues or have suggestions for improvements, please create an issue or a pull request.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
