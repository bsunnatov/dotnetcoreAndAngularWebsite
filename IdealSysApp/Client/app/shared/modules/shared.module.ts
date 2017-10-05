import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';

import { myFocus } from '../../directives/focus.directive';
import { SpinnerComponent } from '../../spinner/spinner.component';
import { TranslatePipe } from '../pipes/translate.pipe';
@NgModule({
    imports: [CommonModule],
    declarations: [myFocus, SpinnerComponent],
    exports: [myFocus, SpinnerComponent],
    providers: []
})
export class SharedModule {
    static forRoot(): ModuleWithProviders {
        return {
            ngModule: SharedModule,
            providers: [ //services that you want to share across modules
                
            ]
        }
    }
}