<a name='assembly'></a>
# Garage

## Contents

- [ColorType](#T-Garage-Types-ColorType 'Garage.Types.ColorType')
  - [ANY](#F-Garage-Types-ColorType-ANY 'Garage.Types.ColorType.ANY')
  - [BLUE](#F-Garage-Types-ColorType-BLUE 'Garage.Types.ColorType.BLUE')
  - [GREEN](#F-Garage-Types-ColorType-GREEN 'Garage.Types.ColorType.GREEN')
  - [RED](#F-Garage-Types-ColorType-RED 'Garage.Types.ColorType.RED')
  - [WHITE](#F-Garage-Types-ColorType-WHITE 'Garage.Types.ColorType.WHITE')
  - [YELLOW](#F-Garage-Types-ColorType-YELLOW 'Garage.Types.ColorType.YELLOW')
- [FuelType](#T-Garage-Types-FuelType 'Garage.Types.FuelType')
  - [DIESEL](#F-Garage-Types-FuelType-DIESEL 'Garage.Types.FuelType.DIESEL')
  - [ELECTRICITY](#F-Garage-Types-FuelType-ELECTRICITY 'Garage.Types.FuelType.ELECTRICITY')
  - [GASOLINE](#F-Garage-Types-FuelType-GASOLINE 'Garage.Types.FuelType.GASOLINE')
- [Garage\`1](#T-Garage-Garage-Garage`1 'Garage.Garage.Garage`1')
  - [#ctor(parkingPlaces,regNumberSlotDict)](#M-Garage-Garage-Garage`1-#ctor-`0[],System-Collections-Generic-IDictionary{System-String,System-Int32}- 'Garage.Garage.Garage`1.#ctor(`0[],System.Collections.Generic.IDictionary{System.String,System.Int32})')
  - [FreeAt(id)](#M-Garage-Garage-Garage`1-FreeAt-System-Int32- 'Garage.Garage.Garage`1.FreeAt(System.Int32)')
  - [GetEmptyIndexes()](#M-Garage-Garage-Garage`1-GetEmptyIndexes 'Garage.Garage.Garage`1.GetEmptyIndexes')
  - [GetEnumerator()](#M-Garage-Garage-Garage`1-GetEnumerator 'Garage.Garage.Garage`1.GetEnumerator')
  - [ParkVehicleInSlot(vehicle,slotId)](#M-Garage-Garage-Garage`1-ParkVehicleInSlot-`0,System-Int32- 'Garage.Garage.Garage`1.ParkVehicleInSlot(`0,System.Int32)')
  - [UnParkVehicle(regNumber)](#M-Garage-Garage-Garage`1-UnParkVehicle-System-String- 'Garage.Garage.Garage`1.UnParkVehicle(System.String)')
  - [VehicleAt(id)](#M-Garage-Garage-Garage`1-VehicleAt-System-Int32- 'Garage.Garage.Garage`1.VehicleAt(System.Int32)')
- [IGarage\`1](#T-Garage-Garage-IGarage`1 'Garage.Garage.IGarage`1')
- [IManager](#T-Garage-Manager-IManager 'Garage.Manager.IManager')
- [IReaderWriter](#T-Garage-UI-IReaderWriter 'Garage.UI.IReaderWriter')
  - [Clear()](#M-Garage-UI-IReaderWriter-Clear 'Garage.UI.IReaderWriter.Clear')
  - [ReadLine()](#M-Garage-UI-IReaderWriter-ReadLine 'Garage.UI.IReaderWriter.ReadLine')
  - [Write(line)](#M-Garage-UI-IReaderWriter-Write-System-String- 'Garage.UI.IReaderWriter.Write(System.String)')
  - [WriteLine(line)](#M-Garage-UI-IReaderWriter-WriteLine-System-String- 'Garage.UI.IReaderWriter.WriteLine(System.String)')
  - [WriteMarker()](#M-Garage-UI-IReaderWriter-WriteMarker 'Garage.UI.IReaderWriter.WriteMarker')
  - [WriteSpaceLine()](#M-Garage-UI-IReaderWriter-WriteSpaceLine 'Garage.UI.IReaderWriter.WriteSpaceLine')
- [ISearchFilter](#T-Garage-Search-ISearchFilter 'Garage.Search.ISearchFilter')
  - [Color](#P-Garage-Search-ISearchFilter-Color 'Garage.Search.ISearchFilter.Color')
  - [ExtraProp](#P-Garage-Search-ISearchFilter-ExtraProp 'Garage.Search.ISearchFilter.ExtraProp')
  - [RegNumber](#P-Garage-Search-ISearchFilter-RegNumber 'Garage.Search.ISearchFilter.RegNumber')
  - [Weels](#P-Garage-Search-ISearchFilter-Weels 'Garage.Search.ISearchFilter.Weels')
  - [ResetAll()](#M-Garage-Search-ISearchFilter-ResetAll 'Garage.Search.ISearchFilter.ResetAll')
  - [ToString()](#M-Garage-Search-ISearchFilter-ToString 'Garage.Search.ISearchFilter.ToString')
- [IUI](#T-Garage-UI-IUI 'Garage.UI.IUI')
- [Manager](#T-Garage-Manager-Manager 'Garage.Manager.Manager')
  - [#ctor(rw,garageHandler,searchFilter,logger,seriLogger)](#M-Garage-Manager-Manager-#ctor-Garage-UI-IReaderWriter,Garage-Garage-IGarageHandler,Garage-Search-ISearchFilter,Garage-Log-IMyLogger,Serilog-ILogger- 'Garage.Manager.Manager.#ctor(Garage.UI.IReaderWriter,Garage.Garage.IGarageHandler,Garage.Search.ISearchFilter,Garage.Log.IMyLogger,Serilog.ILogger)')
  - [MainMenu()](#M-Garage-Manager-Manager-MainMenu 'Garage.Manager.Manager.MainMenu')
  - [Run()](#M-Garage-Manager-Manager-Run 'Garage.Manager.Manager.Run')
- [ReaderWriter](#T-Garage-UI-ReaderWriter 'Garage.UI.ReaderWriter')
  - [#ctor(ui)](#M-Garage-UI-ReaderWriter-#ctor-Garage-UI-IUI- 'Garage.UI.ReaderWriter.#ctor(Garage.UI.IUI)')
  - [Clear()](#M-Garage-UI-ReaderWriter-Clear 'Garage.UI.ReaderWriter.Clear')
  - [ReadLine()](#M-Garage-UI-ReaderWriter-ReadLine 'Garage.UI.ReaderWriter.ReadLine')
  - [Write(line)](#M-Garage-UI-ReaderWriter-Write-System-String- 'Garage.UI.ReaderWriter.Write(System.String)')
  - [WriteLine(line)](#M-Garage-UI-ReaderWriter-WriteLine-System-String- 'Garage.UI.ReaderWriter.WriteLine(System.String)')
  - [WriteMarker()](#M-Garage-UI-ReaderWriter-WriteMarker 'Garage.UI.ReaderWriter.WriteMarker')
  - [WriteSpaceLine()](#M-Garage-UI-ReaderWriter-WriteSpaceLine 'Garage.UI.ReaderWriter.WriteSpaceLine')
- [RegNumberNotFoundException](#T-Garage-Exceptions-RegNumberNotFoundException 'Garage.Exceptions.RegNumberNotFoundException')
  - [#ctor(message)](#M-Garage-Exceptions-RegNumberNotFoundException-#ctor-System-String- 'Garage.Exceptions.RegNumberNotFoundException.#ctor(System.String)')
- [SearchFilter](#T-Garage-Search-SearchFilter 'Garage.Search.SearchFilter')
  - [#ctor()](#M-Garage-Search-SearchFilter-#ctor 'Garage.Search.SearchFilter.#ctor')
  - [Color](#P-Garage-Search-SearchFilter-Color 'Garage.Search.SearchFilter.Color')
  - [ExtraProp](#P-Garage-Search-SearchFilter-ExtraProp 'Garage.Search.SearchFilter.ExtraProp')
  - [RegNumber](#P-Garage-Search-SearchFilter-RegNumber 'Garage.Search.SearchFilter.RegNumber')
  - [Weels](#P-Garage-Search-SearchFilter-Weels 'Garage.Search.SearchFilter.Weels')
  - [ResetAll()](#M-Garage-Search-SearchFilter-ResetAll 'Garage.Search.SearchFilter.ResetAll')
  - [ToString()](#M-Garage-Search-SearchFilter-ToString 'Garage.Search.SearchFilter.ToString')
- [SlotTakenException](#T-Garage-Exceptions-SlotTakenException 'Garage.Exceptions.SlotTakenException')
  - [#ctor(message)](#M-Garage-Exceptions-SlotTakenException-#ctor-System-String- 'Garage.Exceptions.SlotTakenException.#ctor(System.String)')
- [Throw\`1](#T-Garage-Exceptions-Throw`1 'Garage.Exceptions.Throw`1')
- [VehicleExtensions](#T-Garage-Entensions-VehicleExtensions 'Garage.Entensions.VehicleExtensions')
  - [FilterByColor(vehicle,color)](#M-Garage-Entensions-VehicleExtensions-FilterByColor-Garage-Vehicles-IVehicle,System-Nullable{Garage-Types-ColorType}- 'Garage.Entensions.VehicleExtensions.FilterByColor(Garage.Vehicles.IVehicle,System.Nullable{Garage.Types.ColorType})')
  - [FilterByExtraProp(vehicle,filter)](#M-Garage-Entensions-VehicleExtensions-FilterByExtraProp-Garage-Vehicles-IVehicle,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterByExtraProp(Garage.Vehicles.IVehicle,System.Nullable{System.Int32})')
  - [FilterByRegNumber(vehicle,filter)](#M-Garage-Entensions-VehicleExtensions-FilterByRegNumber-Garage-Vehicles-IVehicle,System-String- 'Garage.Entensions.VehicleExtensions.FilterByRegNumber(Garage.Vehicles.IVehicle,System.String)')
  - [FilterByWeels(vehicle,weels)](#M-Garage-Entensions-VehicleExtensions-FilterByWeels-Garage-Vehicles-IVehicle,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterByWeels(Garage.Vehicles.IVehicle,System.Nullable{System.Int32})')
  - [FilterExtraProps(car,fuelType)](#M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-ICar,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterExtraProps(Garage.Vehicles.ICar,System.Nullable{System.Int32})')
  - [FilterExtraProps(bus,seats)](#M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IBus,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterExtraProps(Garage.Vehicles.IBus,System.Nullable{System.Int32})')
  - [FilterExtraProps(motorcycle,cylinderVolume)](#M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IMotorcycle,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterExtraProps(Garage.Vehicles.IMotorcycle,System.Nullable{System.Int32})')
  - [FilterExtraProps(boat,length)](#M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IBoat,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterExtraProps(Garage.Vehicles.IBoat,System.Nullable{System.Int32})')
  - [FilterExtraProps(airplane,engines)](#M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IAirplane,System-Nullable{System-Int32}- 'Garage.Entensions.VehicleExtensions.FilterExtraProps(Garage.Vehicles.IAirplane,System.Nullable{System.Int32})')
  - [GetToString(vehicle)](#M-Garage-Entensions-VehicleExtensions-GetToString-Garage-Vehicles-IVehicle- 'Garage.Entensions.VehicleExtensions.GetToString(Garage.Vehicles.IVehicle)')

<a name='T-Garage-Types-ColorType'></a>
## ColorType `type`

##### Namespace

Garage.Types

##### Summary

Enum defining colors

<a name='F-Garage-Types-ColorType-ANY'></a>
### ANY `constants`

##### Summary

Any, nothing selected

<a name='F-Garage-Types-ColorType-BLUE'></a>
### BLUE `constants`

##### Summary

Blue

<a name='F-Garage-Types-ColorType-GREEN'></a>
### GREEN `constants`

##### Summary

Green

<a name='F-Garage-Types-ColorType-RED'></a>
### RED `constants`

##### Summary

Red

<a name='F-Garage-Types-ColorType-WHITE'></a>
### WHITE `constants`

##### Summary

White

<a name='F-Garage-Types-ColorType-YELLOW'></a>
### YELLOW `constants`

##### Summary

Yellow

<a name='T-Garage-Types-FuelType'></a>
## FuelType `type`

##### Namespace

Garage.Types

##### Summary

Enum defining types of fuel

<a name='F-Garage-Types-FuelType-DIESEL'></a>
### DIESEL `constants`

##### Summary

Diesel

<a name='F-Garage-Types-FuelType-ELECTRICITY'></a>
### ELECTRICITY `constants`

##### Summary

Electricity

<a name='F-Garage-Types-FuelType-GASOLINE'></a>
### GASOLINE `constants`

##### Summary

Gasoline

<a name='T-Garage-Garage-Garage`1'></a>
## Garage\`1 `type`

##### Namespace

Garage.Garage

##### Summary

The garage class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parkingPlaces | [T:Garage.Garage.Garage\`1](#T-T-Garage-Garage-Garage`1 'T:Garage.Garage.Garage`1') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Garage-Garage-Garage`1-#ctor-`0[],System-Collections-Generic-IDictionary{System-String,System-Int32}-'></a>
### #ctor(parkingPlaces,regNumberSlotDict) `constructor`

##### Summary

The garage class

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parkingPlaces | [\`0[]](#T-`0[] '`0[]') |  |
| regNumberSlotDict | [System.Collections.Generic.IDictionary{System.String,System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IDictionary 'System.Collections.Generic.IDictionary{System.String,System.Int32}') |  |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='M-Garage-Garage-Garage`1-FreeAt-System-Int32-'></a>
### FreeAt(id) `method`

##### Summary

Check if a slot is taken

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') |  |

<a name='M-Garage-Garage-Garage`1-GetEmptyIndexes'></a>
### GetEmptyIndexes() `method`

##### Summary

Return indexes for free parking slots

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Garage-Garage-Garage`1-GetEnumerator'></a>
### GetEnumerator() `method`

##### Summary

Get an Enumerator, jump over if null

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Garage-Garage-Garage`1-ParkVehicleInSlot-`0,System-Int32-'></a>
### ParkVehicleInSlot(vehicle,slotId) `method`

##### Summary

Park a vehicle, throw exeption on fail

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [\`0](#T-`0 '`0') |  |
| slotId | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.ArgumentNullException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentNullException 'System.ArgumentNullException') |  |
| [System.ArgumentOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.ArgumentOutOfRangeException 'System.ArgumentOutOfRangeException') |  |
| [Garage.Exceptions.SlotTakenException](#T-Garage-Exceptions-SlotTakenException 'Garage.Exceptions.SlotTakenException') |  |

<a name='M-Garage-Garage-Garage`1-UnParkVehicle-System-String-'></a>
### UnParkVehicle(regNumber) `method`

##### Summary

Unpark a vehicle, throw exeption on fail

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| regNumber | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Garage-Garage-Garage`1-VehicleAt-System-Int32-'></a>
### VehicleAt(id) `method`

##### Summary

Return a vehicle or null. Throw exeption if index is out of range

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.IndexOutOfRangeException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IndexOutOfRangeException 'System.IndexOutOfRangeException') |  |

<a name='T-Garage-Garage-IGarage`1'></a>
## IGarage\`1 `type`

##### Namespace

Garage.Garage

##### Summary

An interface defining a Garage class

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T |  |

<a name='T-Garage-Manager-IManager'></a>
## IManager `type`

##### Namespace

Garage.Manager

##### Summary

Interface defining the Manager class

<a name='T-Garage-UI-IReaderWriter'></a>
## IReaderWriter `type`

##### Namespace

Garage.UI

##### Summary

An interface defining the class of type ReaderWriter

<a name='M-Garage-UI-IReaderWriter-Clear'></a>
### Clear() `method`

##### Summary

As Console.Clear, clear the screen

##### Parameters

This method has no parameters.

<a name='M-Garage-UI-IReaderWriter-ReadLine'></a>
### ReadLine() `method`

##### Summary

As Console.ReadLine, read a line

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Garage-UI-IReaderWriter-Write-System-String-'></a>
### Write(line) `method`

##### Summary

As Console.Write, write without end of line

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| line | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Garage-UI-IReaderWriter-WriteLine-System-String-'></a>
### WriteLine(line) `method`

##### Summary

As Console.WriteLine, write with end of line

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| line | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Garage-UI-IReaderWriter-WriteMarker'></a>
### WriteMarker() `method`

##### Summary

Write a marker using Write

##### Parameters

This method has no parameters.

<a name='M-Garage-UI-IReaderWriter-WriteSpaceLine'></a>
### WriteSpaceLine() `method`

##### Summary

Write a line using WriteLine

##### Parameters

This method has no parameters.

<a name='T-Garage-Search-ISearchFilter'></a>
## ISearchFilter `type`

##### Namespace

Garage.Search

##### Summary

An interface defining a SearchFiler class

<a name='P-Garage-Search-ISearchFilter-Color'></a>
### Color `property`

##### Summary

Color property

<a name='P-Garage-Search-ISearchFilter-ExtraProp'></a>
### ExtraProp `property`

##### Summary

ExtraProp property

<a name='P-Garage-Search-ISearchFilter-RegNumber'></a>
### RegNumber `property`

##### Summary

RegNumber property

<a name='P-Garage-Search-ISearchFilter-Weels'></a>
### Weels `property`

##### Summary

Weels property

<a name='M-Garage-Search-ISearchFilter-ResetAll'></a>
### ResetAll() `method`

##### Summary

Reset all properties

##### Parameters

This method has no parameters.

<a name='M-Garage-Search-ISearchFilter-ToString'></a>
### ToString() `method`

##### Summary

Need ToString in interface, remove warning

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Garage-UI-IUI'></a>
## IUI `type`

##### Namespace

Garage.UI

##### Summary

An intefacee

<a name='T-Garage-Manager-Manager'></a>
## Manager `type`

##### Namespace

Garage.Manager

##### Summary

Main class for handling:
    input from user
    print information
    the garage
    searching
    logging

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rw | [T:Garage.Manager.Manager](#T-T-Garage-Manager-Manager 'T:Garage.Manager.Manager') |  |

<a name='M-Garage-Manager-Manager-#ctor-Garage-UI-IReaderWriter,Garage-Garage-IGarageHandler,Garage-Search-ISearchFilter,Garage-Log-IMyLogger,Serilog-ILogger-'></a>
### #ctor(rw,garageHandler,searchFilter,logger,seriLogger) `constructor`

##### Summary

Main class for handling:
    input from user
    print information
    the garage
    searching
    logging

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| rw | [Garage.UI.IReaderWriter](#T-Garage-UI-IReaderWriter 'Garage.UI.IReaderWriter') |  |
| garageHandler | [Garage.Garage.IGarageHandler](#T-Garage-Garage-IGarageHandler 'Garage.Garage.IGarageHandler') |  |
| searchFilter | [Garage.Search.ISearchFilter](#T-Garage-Search-ISearchFilter 'Garage.Search.ISearchFilter') |  |
| logger | [Garage.Log.IMyLogger](#T-Garage-Log-IMyLogger 'Garage.Log.IMyLogger') |  |
| seriLogger | [Serilog.ILogger](#T-Serilog-ILogger 'Serilog.ILogger') |  |

<a name='M-Garage-Manager-Manager-MainMenu'></a>
### MainMenu() `method`

##### Summary

Show and handle main menu

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Garage-Manager-Manager-Run'></a>
### Run() `method`

##### Summary

Run the program

##### Parameters

This method has no parameters.

<a name='T-Garage-UI-ReaderWriter'></a>
## ReaderWriter `type`

##### Namespace

Garage.UI

##### Summary

A wraper class for IUI. simplier to test and has some strings to print

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ui | [T:Garage.UI.ReaderWriter](#T-T-Garage-UI-ReaderWriter 'T:Garage.UI.ReaderWriter') |  |

<a name='M-Garage-UI-ReaderWriter-#ctor-Garage-UI-IUI-'></a>
### #ctor(ui) `constructor`

##### Summary

A wraper class for IUI. simplier to test and has some strings to print

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| ui | [Garage.UI.IUI](#T-Garage-UI-IUI 'Garage.UI.IUI') |  |

<a name='M-Garage-UI-ReaderWriter-Clear'></a>
### Clear() `method`

##### Summary

As Console.Clear, clear the screen

##### Parameters

This method has no parameters.

<a name='M-Garage-UI-ReaderWriter-ReadLine'></a>
### ReadLine() `method`

##### Summary

As Console.ReadLine, read a line

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Garage-UI-ReaderWriter-Write-System-String-'></a>
### Write(line) `method`

##### Summary

As Console.Write, write without end of line

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| line | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Garage-UI-ReaderWriter-WriteLine-System-String-'></a>
### WriteLine(line) `method`

##### Summary

As Console.WriteLine, write with end of line

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| line | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Garage-UI-ReaderWriter-WriteMarker'></a>
### WriteMarker() `method`

##### Summary

Write a marker using Write

##### Parameters

This method has no parameters.

<a name='M-Garage-UI-ReaderWriter-WriteSpaceLine'></a>
### WriteSpaceLine() `method`

##### Summary

Write a line using WriteLine

##### Parameters

This method has no parameters.

<a name='T-Garage-Exceptions-RegNumberNotFoundException'></a>
## RegNumberNotFoundException `type`

##### Namespace

Garage.Exceptions

##### Summary

Exeption used when a vehicle is not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [T:Garage.Exceptions.RegNumberNotFoundException](#T-T-Garage-Exceptions-RegNumberNotFoundException 'T:Garage.Exceptions.RegNumberNotFoundException') |  |

<a name='M-Garage-Exceptions-RegNumberNotFoundException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Exeption used when a vehicle is not found

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Garage-Search-SearchFilter'></a>
## SearchFilter `type`

##### Namespace

Garage.Search

##### Summary

A class for storing searh filer parameters

<a name='M-Garage-Search-SearchFilter-#ctor'></a>
### #ctor() `constructor`

##### Summary

A default constructor, maybe not needed

##### Parameters

This constructor has no parameters.

<a name='P-Garage-Search-SearchFilter-Color'></a>
### Color `property`

##### Summary

Color property

<a name='P-Garage-Search-SearchFilter-ExtraProp'></a>
### ExtraProp `property`

##### Summary

ExtraProp property

<a name='P-Garage-Search-SearchFilter-RegNumber'></a>
### RegNumber `property`

##### Summary

RegNumber property

<a name='P-Garage-Search-SearchFilter-Weels'></a>
### Weels `property`

##### Summary

Weels property

<a name='M-Garage-Search-SearchFilter-ResetAll'></a>
### ResetAll() `method`

##### Summary

Reset all properties

##### Parameters

This method has no parameters.

<a name='M-Garage-Search-SearchFilter-ToString'></a>
### ToString() `method`

##### Summary

Need ToString in interface, remove warning

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Garage-Exceptions-SlotTakenException'></a>
## SlotTakenException `type`

##### Namespace

Garage.Exceptions

##### Summary

Exeption used when a parking slot is taken

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [T:Garage.Exceptions.SlotTakenException](#T-T-Garage-Exceptions-SlotTakenException 'T:Garage.Exceptions.SlotTakenException') |  |

<a name='M-Garage-Exceptions-SlotTakenException-#ctor-System-String-'></a>
### #ctor(message) `constructor`

##### Summary

Exeption used when a parking slot is taken

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='T-Garage-Exceptions-Throw`1'></a>
## Throw\`1 `type`

##### Namespace

Garage.Exceptions

##### Summary

A class for throwing exception T when isValid is true

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The exception type |

<a name='T-Garage-Entensions-VehicleExtensions'></a>
## VehicleExtensions `type`

##### Namespace

Garage.Entensions

##### Summary

A class containing Extension methods for IVehicle

<a name='M-Garage-Entensions-VehicleExtensions-FilterByColor-Garage-Vehicles-IVehicle,System-Nullable{Garage-Types-ColorType}-'></a>
### FilterByColor(vehicle,color) `method`

##### Summary

Filter a Vehicle by Color, can be used in Linq

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [Garage.Vehicles.IVehicle](#T-Garage-Vehicles-IVehicle 'Garage.Vehicles.IVehicle') |  |
| color | [System.Nullable{Garage.Types.ColorType}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{Garage.Types.ColorType}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterByExtraProp-Garage-Vehicles-IVehicle,System-Nullable{System-Int32}-'></a>
### FilterByExtraProp(vehicle,filter) `method`

##### Summary

Filter a Vehicle by ExtraProp, can be used in Linq
Go to different methids depending of sub class

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [Garage.Vehicles.IVehicle](#T-Garage-Vehicles-IVehicle 'Garage.Vehicles.IVehicle') |  |
| filter | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterByRegNumber-Garage-Vehicles-IVehicle,System-String-'></a>
### FilterByRegNumber(vehicle,filter) `method`

##### Summary

Filter a Vehicle by RegNumber, can be used in Linq

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [Garage.Vehicles.IVehicle](#T-Garage-Vehicles-IVehicle 'Garage.Vehicles.IVehicle') |  |
| filter | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterByWeels-Garage-Vehicles-IVehicle,System-Nullable{System-Int32}-'></a>
### FilterByWeels(vehicle,weels) `method`

##### Summary

Filter a Vehicle by Weels, can be used in Linq

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [Garage.Vehicles.IVehicle](#T-Garage-Vehicles-IVehicle 'Garage.Vehicles.IVehicle') |  |
| weels | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-ICar,System-Nullable{System-Int32}-'></a>
### FilterExtraProps(car,fuelType) `method`

##### Summary

Filter a Car by ExtraProp, called from FilterByExtraProp

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| car | [Garage.Vehicles.ICar](#T-Garage-Vehicles-ICar 'Garage.Vehicles.ICar') |  |
| fuelType | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IBus,System-Nullable{System-Int32}-'></a>
### FilterExtraProps(bus,seats) `method`

##### Summary

Filter a Bus by ExtraProp, called from FilterByExtraProp

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bus | [Garage.Vehicles.IBus](#T-Garage-Vehicles-IBus 'Garage.Vehicles.IBus') |  |
| seats | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IMotorcycle,System-Nullable{System-Int32}-'></a>
### FilterExtraProps(motorcycle,cylinderVolume) `method`

##### Summary

Filter a Motorcycle by ExtraProp, called from FilterByExtraProp

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| motorcycle | [Garage.Vehicles.IMotorcycle](#T-Garage-Vehicles-IMotorcycle 'Garage.Vehicles.IMotorcycle') |  |
| cylinderVolume | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IBoat,System-Nullable{System-Int32}-'></a>
### FilterExtraProps(boat,length) `method`

##### Summary

Filter a Boat by ExtraProp, called from FilterByExtraProp

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| boat | [Garage.Vehicles.IBoat](#T-Garage-Vehicles-IBoat 'Garage.Vehicles.IBoat') |  |
| length | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-FilterExtraProps-Garage-Vehicles-IAirplane,System-Nullable{System-Int32}-'></a>
### FilterExtraProps(airplane,engines) `method`

##### Summary

Filter an Airplane by ExtraProp, called from FilterByExtraProp

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| airplane | [Garage.Vehicles.IAirplane](#T-Garage-Vehicles-IAirplane 'Garage.Vehicles.IAirplane') |  |
| engines | [System.Nullable{System.Int32}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Nullable 'System.Nullable{System.Int32}') |  |

<a name='M-Garage-Entensions-VehicleExtensions-GetToString-Garage-Vehicles-IVehicle-'></a>
### GetToString(vehicle) `method`

##### Summary

Get to string value for the vehicle subtype

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| vehicle | [Garage.Vehicles.IVehicle](#T-Garage-Vehicles-IVehicle 'Garage.Vehicles.IVehicle') |  |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [System.NullReferenceException](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.NullReferenceException 'System.NullReferenceException') |  |
