#include<stdio.h>

int main()
{
    int n;
    int pid[20], at[20], bt[20], wt[20], tat[20], rt[20];
    float avg_tat = 0, avg_wt = 0;

    printf("Enter the number of processes: ");
    scanf("%d", &n);

    printf("Enter the Arrival Time and Burst Time of the processes: ");
    for (int i = 0; i < n; i++) {
        pid[i] = i+1;
        printf("Enter the arrival time: ");
        scanf("%d", &at[i]);
        printf("Enter the burst time: ");
        scanf("%d", &bt[i]);


    }

    for(int i=0; i < n-1; i++){
        for(int j = i+1; j< n; j++){
            if(at[i]>at[j]){
                int temp;
                temp = at[i]; at[i] = at[j]; at[j] = temp;
                temp = bt[i]; bt[i] = bt[j]; bt[j] = temp;
                temp = pid[i]; pid[i] = pid[j]; pid[j] = temp;
            }
        }
    }

    wt[0] = 0;


    for(int i = 0; i<n;i++){
        wt[i] = (wt[i-1] + bt[i-1] - bt[i]) - at[i];
        if(wt[i]<0) wt[0] = 0;
    }

    for(int i = 0; i<n; i++){
        tat[i] = bt[i] + wt[i];
    }
     for (int i = 0; i < n; i++) {
        printf("P[%d]\t%d\t\t%d\t\t%d\t\t%d\n", pid[i], at[i], bt[i], wt[i], tat[i]);
        avg_wt += wt[i];
        avg_tat += tat[i];
    }

    avg_wt /= n;
    avg_tat /= n;

    printf("\nAverage Waiting Time: %.2f", avg_wt);
    printf("\nAverage Turnaround Time: %.2f\n", avg_tat);
}