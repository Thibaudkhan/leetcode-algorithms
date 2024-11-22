$iterations = 10
$outputDir = "${PWD}/artifacts"
$summaryFile = "$outputDir/Benchmark-Summary.csv"

# Créer le répertoire des résultats s'il n'existe pas
if (-not (Test-Path $outputDir)) {
    New-Item -ItemType Directory -Path $outputDir
}

# Tableau pour stocker les résultats intermédiaires
$allResults = @()

# Lancer les benchmarks et collecter les données
for ($i = 1; $i -le $iterations; $i++) {
    Write-Host "Running benchmark iteration $i of $iterations..."
    $outputFile = "$outputDir/Benchmark-Run-$i.log"
    
    docker run --rm --network none --cpus=2 --memory=2g `
        -v ${outputDir}:/app/BenchmarkDotNet.Artifacts `
        benchmark-dotnet > $outputFile

    Write-Host "Benchmark iteration $i completed. Results saved to $outputFile"

    # Lire les lignes contenant les résumés à partir des fichiers log
    $results = Select-String -Path $outputFile -Pattern '^\| [A-Za-z]' |
               ForEach-Object { ($_ -replace '\|', '').Trim() -replace '\s+', ',' }
    $allResults += $results
}

# Ajouter les entêtes pour le CSV
$csvHeaders = "Method,NumberOfProducts,Mean,Error,StdDev,Median,Min,Max,Allocated"
$csvContent = @($csvHeaders)

# Ajouter les lignes dans le fichier CSV
$csvContent += $allResults
$csvContent | Out-File -FilePath $summaryFile -Encoding UTF8

Write-Host "Summary saved to $summaryFile"
