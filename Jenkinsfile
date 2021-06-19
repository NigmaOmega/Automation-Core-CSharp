pipeline {
    agent any
    stages {
        stage('Tests') {
            steps {
                sh "export PATH=${PATH}:${HOME}/.dotnet/tools"
                sh returnStatus: true, script: "dotnet test \"${workspace}/Core-DotnetCore.sln\" --logger \"nunit;LogFileName=results.xml\""
            }
        }
    }
}


