// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function createYearlyCrashChart() {
    const table = document.querySelector('table');
    const rows = table.getElementsByTagName('tbody')[0].getElementsByTagName('tr');

    const years = Array.from(rows, row => row.getElementsByTagName('td')[3].textContent);
    const uniqueYears = Array.from(new Set(years));

    const yearCounts = uniqueYears.map(year => {
        const count = years.filter(y => y === year).length;
        return count;
    });

    const ctx = document.getElementById('yearlyCrashChart').getContext('2d');
    new Chart(ctx, {
        type: 'bar',
        data: {
            labels: uniqueYears,
            datasets: [{
                label: 'Crashes by Year',
                data: yearCounts,
                backgroundColor: 'rgba(75, 192, 192, 0.2)',
                borderColor: 'rgba(75, 192, 192, 1)',
                borderWidth: 1,
            }],
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true,
                },
            },
        },
    });
}

// Call the function to generate the bar chart



