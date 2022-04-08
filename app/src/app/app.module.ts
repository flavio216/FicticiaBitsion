import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { HomeComponent } from './home/home.component';
import { ClientComponent } from './client/client.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { Dialogclientcomponent } from './client/dialog/dialogclientcomponent';
import { FormsModule } from '@angular/forms';
import { MatCardModule} from '@angular/material/card';
import { DialogDeleteComponent } from './client/common/dialogdelete.component';
import { LoginComponent } from './login/login.component';
//import { JwtInterceptor } from './security/jwt.interceptor';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ClientComponent,
    Dialogclientcomponent,
    DialogDeleteComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    HttpClientModule,
    MatTableModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatSnackBarModule,
    FormsModule
  ],
  providers: [
    /*{
      provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true
    }*/
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
