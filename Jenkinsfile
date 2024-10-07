pipeline {
    agent any

    stages {
        stage('Clone Repository') {
            steps {
                script {
                    // Clone kho lưu trữ từ GitHub
                    git url: 'https://github.com/TienMinh1998/SPN.microservice.v3.git', branch: 'main' // Thay đổi 'main' thành nhánh bạn muốn nếu cần
                }
            }
        }

        // Bạn có thể thêm các giai đoạn khác ở đây nếu cần
    }
}