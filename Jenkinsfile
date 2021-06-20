pipeline {
     agent any

    tools{
        dotnetsdk 'dotnet'
    }

    stages {
        stage('Tests') {
            steps {
                sh returnStatus: true, script: "dotnet test \"${workspace}/Core-DotnetCore.sln\"
            }
        }
    }
}


