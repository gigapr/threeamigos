#!/bin/bash
set -e
print(){
    local Green='\033[0;32m'
    local NoColor='\033[0m'
    local message=$1
    echo -e "${Green}${message}${NoColor}"
}
build(){
    local path=$1
    local config=$2
    print "Starting building $path in $config mode."
    dotnet build "$path" --configuration "$config"
}
run_tests(){
    local path=$1
    local config=$2
    find . -name "*.Tests.csproj"|while read fname; do
    print "Starting running tests for $fname using $config mode."
    dotnet test "$fname" --configuration "$config" --no-build --no-restore /p:CollectCoverage=true /p:Exclude=[xunit.*]*
    done
}
pack(){
    local projectPath=$1
    local output=$2
    local config=$3
    print "Starting packing $projectPath $config into $output."
    dotnet pack "$projectPath" --configuration "$config" --output "$output" --no-build
}
usage(){
    print 'Usage:'
    print './build.sh | Execute build, test'
    print './build.sh build [Release|Debug] | Restore packages and build the solution'
    print './build.sh test [Release|Debug] | Run all tests in the solution'
    print './build.sh pack outputDirectory [Release|Debug] | Package the Web project into the output directory'
    print './build.sh all outputDirectory [Release|Debug] | Execute build, test, pack'
    print './build.sh help | Show this screen'
    print ''
    print 'The configuration value [Release|Debug] is optional for all the commands. The default value is Release.'
    print ''
}

directory=$(dirname "$0")
solutionPath="$directory/src/TrafficSignalsConfigurator.sln"
webProjectPath="$directory/src/TrafficSignalsConfigurator/TrafficSignalsConfigurator.Web.csproj"
usage
target=${1:-'default'}

case ${target} in
    'build')
            configuration=${2:-Release}
            build $solutionPath $configuration
        ;;
    'test')
            configuration=${2:-Release}
            run_tests $solutionPath $configuration
        ;;
    'pack')
            outputDirectory=${2:-'../../output'}
            configuration=${3:-Release}
            pack $webProjectPath $outputDirectory $configuration
        ;;

    'help')
        usage
    ;;

    'all')
        outputDirectory=${2:-'../../output'}
        configuration=${3:-Release}
        build $solutionPath $configuration
        run_tests $solutionPath $configuration
        pack $webProjectPath $outputDirectory $configuration
    ;;

    'default')
        configuration=${2:-Release}
        build $solutionPath $configuration
        run_tests $solutionPath $configuration
    ;;

esac