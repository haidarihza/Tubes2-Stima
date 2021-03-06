BIN_NAME = Stima2.exe
BUILD_BIN = bin\Debug\net6.0-windows\$(BIN_NAME)
PBLSH_BIN = bin\Publish\$(BIN_NAME)

$(BUILD_BIN):
	dotnet build

$(PBLSH_BIN):
	dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained -o bin\Publish

build: $(BUILD_BIN)

compile: $(PBLSH_BIN)

build-run: $(BUILD_BIN)
	$<

compile-run: $(PBLSH_BIN)
	$<

clean:
	rm -rf bin
	rm -rf obj