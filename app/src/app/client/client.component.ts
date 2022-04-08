import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiClientService } from '../services/apiclient.service';
import { Response } from '../models/response';
import { Dialogclientcomponent } from './dialog/dialogclientcomponent';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatSortModule } from '@angular/material/sort';
import { Client } from '../models/client';
import { DialogDeleteComponent } from './common/dialogdelete.component';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.scss']
})
export class ClientComponent implements OnInit {

  public lst: any[]= [];
  readonly width: string = '300px';
  public columnas: string[] = ['cliId', 'cliName', 'cliDni', 'cliDocDocumentType', 'cliGenGender', 'cliActive', 'cliDrive', 'cliUseGlasses', 'cliDiabetic', 'cliOtherDiseases', 'cliDiseases','actions'];
  constructor(
    private apiClient: ApiClientService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ){
    this.apiClient.getClientes().subscribe(response =>{
      this.lst = response.data; 
  })
}
  getClientes(){
    this.apiClient.getClientes().subscribe(response =>{
      this.lst = response.data; 
  })  
  }

getDocumentType(){
    this.apiClient.getDocumentType().subscribe(response =>{
      this.lst = response.data; 
      console.log(this.lst);
  })  
  }
  
  openAdd(){
    const dialogRef = this.dialog.open(Dialogclientcomponent, {
      width: this.width
    })
    dialogRef.afterClosed().subscribe(result =>{
      this.getClientes();
    })
  }

  openEdit(client: Client){
    const dialogRef = this.dialog.open(Dialogclientcomponent, {
      data: client,
      width: this.width
      
    })
    dialogRef.afterClosed().subscribe(result =>{
      this.getClientes();
    })
  }

  Delete(client:Client){
    const dialogRef = this.dialog.open(DialogDeleteComponent, {
      width: this.width
    });
    dialogRef.afterClosed().subscribe(result => {
      if(result){
        this.apiClient.delete(client.cliId).subscribe(response => {
          if(response.success === 1){
            
            this.snackBar.open('Client deleted successfully', '',{
              duration: 2000
            });
            
            this.getClientes();
          }
          
        });
      }
    });
  }

  ngOnInit(): void {
    this.getClientes();
  }

}
