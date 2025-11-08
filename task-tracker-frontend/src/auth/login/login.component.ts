import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../core/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {
    this.loginForm = this.fb.group({ username: ['', Validators.required], password: ['', Validators.required] });
  }

  submit() {
    if (this.loginForm.invalid) return;
    const { username, password } = this.loginForm.value;
    this.auth.login(username, password).subscribe({
      next: () => this.router.navigate(['/tasks']),
      error: err => alert(err.error || 'Login failed')
    });
  }
}
