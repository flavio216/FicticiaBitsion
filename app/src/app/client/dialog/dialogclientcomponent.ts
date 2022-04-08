import { Component, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";
import { ApiClientService } from "src/app/services/apiclient.service";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Client } from "src/app/models/client";
import { FormGroup, FormControl, FormBuilder, Validators } from "@angular/forms";
@Component(
    {
        templateUrl: "dialogclientcomponent.html"
    }
)
export class Dialogclientcomponent{
   /* public clientForm = this.formBuilder.group({
        cliId: ['',Validators.required],
        cliName: ['',Validators.required],
        cliDni: ['',Validators.required],
        cliDocDocumentType: ['',Validators.required],
        cliGenGender: ['',Validators.required],
        cliDrive: ['',Validators.required],
        cliUseGlasses: ['',Validators.required],
        cliDiabetic: ['',Validators.required],
        cliOtherDiseases: ['',Validators.required],
        cliDiseases: ['',Validators.required]

    });*/
    /*public clientForm = new FormGroup({
        cliId: new FormControl(''),
        cliName: new FormControl(''),
        cliDni: new FormControl(''),
        cliDocDocumentType: new FormControl(''),
        cliGenGender: new FormControl(''),
        cliDrive: new FormControl(''),
        cliUseGlasses: new FormControl(''),
        cliDiabetic: new FormControl(''),
        cliOtherDiseases: new FormControl(''),
        cliDiseases: new FormControl('')

    });*/
    public cliId : number = 0;
    public cliName : string = "";
    public cliDni : string = "";
    public cliDocDocumentType : number = 0;
    public cliGenGender : number = 0;
    public cliDrive : boolean = true;
    public cliUseGlasses : boolean = true;
    public cliDiabetic : boolean = true;
    public cliOtherDiseases : boolean = true;
    public cliDiseases : string = "";
    constructor(
            public dialogRef: MatDialogRef<Dialogclientcomponent>,
            public apiClient: ApiClientService,
            public snackBar: MatSnackBar,
            @Inject(MAT_DIALOG_DATA) public cliente: Client
            
    ){
        if(this.cliente !== null){
            this.cliId = cliente.cliId;
            this.cliName = cliente.cliName;
            this.cliDni = cliente.cliDni;
            this.cliDocDocumentType = cliente.cliDocDocumentType;
            this.cliGenGender = cliente.cliGenGender;
            this.cliDrive = cliente.cliDrive;
            this.cliUseGlasses = cliente.cliUseGlasses;
            this.cliDiabetic = cliente.cliDiabetic;
            this.cliOtherDiseases = cliente.cliOtherDiseases;
            this.cliDiseases = cliente.cliDiseases;
        }
    } 
    close(){
        this.dialogRef.close();
    }

    editClient(){
        const cliente: Client = {cliId: this.cliId, cliName: this.cliName, cliDni: this.cliDni, cliDocDocumentType: this.cliDocDocumentType, cliGenGender: this.cliGenGender, cliDrive: this.cliDrive, cliUseGlasses: this.cliUseGlasses, cliDiabetic: this.cliDiabetic, cliOtherDiseases: this.cliOtherDiseases, cliDiseases: this.cliDiseases};
        console.log('client');
        this.apiClient.edit(cliente).subscribe(response =>{
            if(response.success === 1)
            this.dialogRef.close();
            this.snackBar.open('Customer successfully edited','',{
                duration: 2000
            });
        })

    }


    addClient(){
        const client: Client = {cliId: this.cliId,cliName: this.cliName, cliDni: this.cliDni, cliDocDocumentType: this.cliDocDocumentType, cliGenGender: this.cliGenGender, cliDrive: this.cliDrive, cliUseGlasses: this.cliUseGlasses, cliDiabetic: this.cliDiabetic, cliOtherDiseases: this.cliOtherDiseases, cliDiseases: this.cliDiseases};  
        console.log('client');
        this.apiClient.add(client).subscribe(response =>{
            if(response.success === 1)
            this.dialogRef.close();
            this.snackBar.open('Client successfully inserted','',{
                duration: 2000
            });
        })
    }
}