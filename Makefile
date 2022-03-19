P_BIN = bin
BUILD_BIN = bin\Debug\net6.0-windows\Stima2.exe

compile:
	mkdir -p $(P_BIN)
	dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained -o bin\Publish

$(BUILD_BIN):
	dotnet build

build: $(BUILD_BIN)

run: $(BUILD_BIN)
	$<

clean:
	rm -rf $(P_BIN)