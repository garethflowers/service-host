# Service Host

A server utility for hosting any application as a Windows Service.

## Usage

Generate your required service by issuing an `sc create`.

```
set SERVICENAME=TestService
set DISPLAYNAME=Test Windows Service
set BINPATH=ServiceHost.exe FILENAME [ARGUMENTS]

sc create %SERVICENAME% binpath= "%BINPATH%" displayname= "%NAME%"
```

## License

Do what you like. See [LICENSE](https://github.com/garethflowers/service-host/blob/master/LICENSE) (MIT).
