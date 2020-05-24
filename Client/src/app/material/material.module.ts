import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule, MatDialogModule, MatSidenavModule, MatIconModule, MatExpansionModule, MatFormFieldModule, MatInputModule, MatRippleModule, MatMenuModule, MatRipple, MatCheckboxModule, MatProgressBarModule, MatCardModule} from "@angular/material"

const MaterialComponent = [
  MatButtonModule,
  MatDialogModule,
  MatSidenavModule,
  MatIconModule,
  MatExpansionModule,
  MatInputModule,
  MatMenuModule,
  MatRippleModule,
  MatCheckboxModule,
  MatProgressBarModule,
  MatCardModule
]


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MaterialComponent
  ],
  exports:[
    MaterialComponent
  ]
})
export class MaterialModule { }
