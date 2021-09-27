# Reinforcement and Imitation Learning for Multi-Agent 3D Racing: A Comparison
Vision-based approaches have dominated the scene of Reinforcement Learning (RL) when applied to autonomous driving agents due to being a cheaper alternative. Addressing a lack of research on other techniques, this project introduces a sensor-based racing environment for multiple agents. The Soft-Actor Critic (SAC) and Proximal Policy Optimization (PPO) RL algorithms are applied to this environment to determine whether on-policy algorithms are better suited towards autonomous sensor-based driving, or if off-policy techniques are superior. Hybrid approaches through Imitation Learning are also explored which apply Generative Adversarial Imitation Learning (GAIL) and Behavioural Cloning (BC). Results indicate that the off-policy SAC models are better suited towards sensor-based racing by adopting a competitive approach. Additionally, these are also shown to be better at avoiding undesired actions such as collisions with other cars. On the other hand, PPO agents have favoured a cooperative approach which led to safer track navigation at the expense of velocity. Such behaviours could all be fully appreciated within the paper's video

> Please refer to the project report for further information

### Video Demo
Link: https://youtu.be/MEz6-LGSXNk

[![Watch the video](https://img.youtube.com/vi/MEz6-LGSXNk/maxresdefault.jpg)](https://youtu.be/MEz6-LGSXNk)
