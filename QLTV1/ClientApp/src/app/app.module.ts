import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SachComponent } from './sach/sach.component';
import { DocgiaComponent } from './docgia/docgia.component';
import { TheloaiComponent } from './theloai/theloai.component';
import { ThethuvienComponent } from './thethuvien/thethuvien.component';
import { TacgiaComponent } from './tacgia/tacgia.component';
import { CtmuontraComponent } from './ctmuontra/ctmuontra.component';
import { MuontraComponent } from './muontra/muontra.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    SachComponent,
    DocgiaComponent,
    TheloaiComponent,
    ThethuvienComponent,
    TacgiaComponent,
    CtmuontraComponent,
    MuontraComponent
    
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'sach', component: SachComponent },
      { path: 'docgia', component: DocgiaComponent },
      { path: 'theloai', component: TheloaiComponent },
      { path: 'thethuvien', component: ThethuvienComponent },
      { path: 'tacgia', component: TacgiaComponent },
      { path: 'muontra', component: MuontraComponent },
      { path: 'ctmuontra', component:CtmuontraComponent  },
      
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
