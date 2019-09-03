declare var envprocess: Process;

interface Process {
  env: Env
}
interface Env {
  ENV: string;
  API: string;
}
interface GlobalEnvironment
{
  process: Process
}
